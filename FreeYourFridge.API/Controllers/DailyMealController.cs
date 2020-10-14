using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using FreeYourFridge.API.Data.Interfaces;
using FreeYourFridge.API.DTOs;
using FreeYourFridge.API.Filters;
using FreeYourFridge.API.Models;
using FreeYourFridge.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreeYourFridge.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/dailymeal")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class DailyMealController : ControllerBase
    {
        private readonly IDailyMealRepository _repoUser;
        private readonly IMapper _mapper;
        private readonly DCICalculator _calc;

        public DailyMealController(IDailyMealRepository repository, IMapper mapper, DCICalculator calc)
        {
            _repoUser = repository;
            _mapper = mapper;
            _calc = calc;
        }

        /// <summary>
        /// Gets list of current daily meals
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetDailyMeals()
        {
            var meals = await _repoUser.GetDailyMealsAsync();

            var mealsFiltered = meals.Where(dm =>
                dm.CreatedBy == int.Parse(User.FindFirst(claim =>
                    claim.Type == ClaimTypes.NameIdentifier).Value));
            return Ok(_mapper.Map<List<DailyMealBasicDto>>(mealsFiltered));
        }


        /// <summary>
        ///  Gets daily meal stored in database
        /// </summary>
        /// <param name="id">spoonacular id of the recipe </param>
        /// <returns>DailyMealBasicDto</returns>
        [HttpGet]
        [Route("{id}", Name = "GetDailyMeal")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSingleDailyMeal(int id)
        {
            var dMeal = await _repoUser.GetDailyMealAsync(id);
            return dMeal == null
                ? throw new ArgumentNullException(nameof(dMeal))
                : Ok(_mapper.Map<DailyMealBasicDto>(dMeal));
        }


        /// <summary>
        ///  Returns details of daily meal  
        /// </summary>
        /// <param name="id"> spoonacular id of the recipe </param>
        /// <returns>DailyMealDetailsDto</returns>
        [HttpGet("{id}/details")]
        [DailMealFilter]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSingleDailyMealDetails(int id)
        {
            var dMealLocal = await _repoUser.GetDailyMealAsync(id);
            if (dMealLocal != null)
            {
                var incomMeal = await _repoUser.GetExternalDailyMeal(id);
                (Models.DailyMeal dMeal, ExternalModels.IncomingRecipe iRecipe) = (dMealLocal, incomMeal);
                return Ok((dMealLocal, incomMeal));
            }
            return NotFound();
        }


        /// <summary>
        /// add DailyMeal; called only once after addDailyMeal from recipe-detail-component.ts (Angular)
        /// </summary>
        /// <param name="dailyMealToAddDto"></param>
        /// <returns>BadRequest or 409 if record exists or calls GetSingleDailyMeal </returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> AddDailyMeal([FromBody] DailyMealToAddDto dailyMealToAddDto)
        {
            if (!ModelState.IsValid || dailyMealToAddDto == null) return BadRequest(dailyMealToAddDto);
            var record = await _repoUser.GetDailyMealAsync(dailyMealToAddDto.Id);
            if (record != null) return StatusCode(409);

            var userId = int.Parse(User.FindFirst(claim => claim.Type == ClaimTypes.NameIdentifier).Value);
            if (!(await _calc.CheckIfFilledDCI(userId))) return BadRequest();
            await CheckTimeInEntityTable();

            var dMealToAdd = _mapper.Map<Models.DailyMeal>(dailyMealToAddDto);
            await AddDailyMealWithUserId(dMealToAdd, userId);

            await _calc.AdjustDailyDemand(userId);
            return CreatedAtRoute("GetDailyMeal", new { dMealToAdd.Id }, null);
        }


        /// <summary>
        /// Updates daily Meal - called by Angular from dailyMeadDetails.component.ts
        /// </summary>
        /// <param name="dailyMealToAddDto"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateDailyMeal([FromBody] DailyMealToAddDto dailyMealToAddDto)
        {
            if (!ModelState.IsValid || dailyMealToAddDto == null) return BadRequest();
            var dMeal = await _repoUser.GetDailyMealAsync(dailyMealToAddDto.Id);
            if (dMeal == null) return BadRequest();
            await UpdateGramsTitleRemarksInDailyMeal(dailyMealToAddDto, dMeal);
            return NoContent();
        }


        #region private

        /// <summary>
        /// Clears table when added the first dailymeal a day
        /// </summary>
        /// <returns>void</returns>
        private async Task CheckTimeInEntityTable()
        {
            var meals = await _repoUser.GetDailyMealsAsync();
            var lastMeal = meals
                .OrderBy(m => m.TimeOfLastMeal)
                .LastOrDefault();
            if (lastMeal != null)
            {
                if (DateTime.Now.DayOfYear - lastMeal.TimeOfLastMeal.DayOfYear >= 1)
                {
                    await ArchiveDailyMeals(meals);
                    await _repoUser.ClearTable();
                    await _repoUser.SaveChangesAsync();
                }
            }
        }
        private async Task ArchiveDailyMeals(IEnumerable<DailyMeal> dailyMeals)
        {
            foreach (var dailyMeal in dailyMeals)
            {
                var dmealToArchive = _mapper.Map<DailyMealToArchive>(dailyMeal);
                dmealToArchive.DateTimeAddDeailyMeal = DateTime.Now;
                _repoUser.AddDailyMealsToArchive(dmealToArchive);
            }
            await _repoUser.SaveChangesAsync();
        }
        private async Task AddDailyMealWithUserId(DailyMeal dMealToAdd, int userId)
        {
            dMealToAdd.TimeOfLastMeal = DateTime.Now;
            dMealToAdd.CreatedBy = userId;
            dMealToAdd.CaloriesPerPortion =
                await _calc.CalculaCaloriesPerPortion(dMealToAdd.Id, dMealToAdd.Grams);
            _repoUser.AddMeal(dMealToAdd);
            await _repoUser.SaveChangesAsync();
        }
        private async Task UpdateGramsTitleRemarksInDailyMeal(DailyMealToAddDto dailyMealToAddDto, DailyMeal dMeal)
        {
            dMeal.Grams = dailyMealToAddDto.Grams;
            dMeal.Title = dailyMealToAddDto.Title;
            dMeal.UserRemarks = dailyMealToAddDto.UserRemarks;
            _repoUser.UpdateMeal(dMeal);
            await _repoUser.SaveChangesAsync();
        }
        #endregion
    }
}

