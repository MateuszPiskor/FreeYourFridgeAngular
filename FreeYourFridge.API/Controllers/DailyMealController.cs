using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FreeYourFridge.API.Data;
using FreeYourFridge.API.Data.Interfaces;
using FreeYourFridge.API.DTOs;
using FreeYourFridge.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace FreeYourFridge.API.Controllers
{
    [ApiController]
    [Route("api/dailymeal")]
    public class DailyMealController:ControllerBase
    {
        private readonly IDailyMealRepository _repository;
        private readonly IMapper _mapper;

        public DailyMealController(IDailyMealRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetDailyMeals()
        {
            var meals= await _repository.GetDailyMealsAsync();
            return Ok(_mapper.Map<List<DailyMealBasicDto>>(meals));
        }

        [HttpGet("{id}")]
        [Route("{id}", Name="GetDailyMeal")]
        public async Task<IActionResult> GetSingleDailyMeal(int id)
        {
            var dMeal = await _repository.GetDailyMealAsync(id);
            return Ok(_mapper.Map<DailyMealBasicDto>(dMeal));
        }

        [HttpGet("{id}/details")]
        [Route("{id}", Name = "GetDailyMealDetails")]
        public async Task<IActionResult> GetSingleDailyMealDetails(int id)
        {
            var dMeal = await _repository.GetDailyMealAsync(id);
            return Ok(_mapper.Map<DailyMealDetailedDto>(dMeal));
        }

        /// <summary>
        /// add DailyMeal; called only once after addDailyMeal from recipe-detail-component.ts (Angular)
        /// </summary>
        /// <param name="dailyMealToAddDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("application/json")]

        public async Task<IActionResult> AddDailyMeal([FromBody] DailyMealToAddDto dailyMealToAddDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var record = await _repository.GetDailyMealAsync(dailyMealToAddDto.Id);
            if (record != null)
            {
                if (record.Id == dailyMealToAddDto.Id)
                {
                    return StatusCode(302);
                }
                await CheckTimeInEntityTable();
            }

            var dMealToAdd = _mapper.Map<Models.DailyMeal>(dailyMealToAddDto);
            dMealToAdd.TimeOfLastMeal = DateTime.Now;
            await _repository.AddMeal(dMealToAdd);
            return CreatedAtRoute("GetDailyMeal", new { dMealToAdd.Id }, null);

        }

        /// <summary>
        /// Updates daily Meal - called by Angular from dailyMeadDetails.component.ts
        /// </summary>
        /// <param name="dailyMealToAddDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateDailyMeal([FromBody] DailyMealToAddDto dailyMealToAddDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            
            var dMeal = await _repository.GetDailyMealAsync(dailyMealToAddDto.Id);
            if (dMeal == null) return BadRequest();
            if (dMeal.TimeOfLastMeal.TimeOfDay > DateTime.Now.TimeOfDay) await _repository.ClearTable();

            dMeal.Grams = dailyMealToAddDto.Grams;
            dMeal.Title = dailyMealToAddDto.Title;
            dMeal.UserRemarks = dailyMealToAddDto.UserRemarks;
            dMeal.TimeOfLastMeal = DateTime.Now;

            await _repository.UpdateMeal(dMeal);
            return NoContent();
        }

        private async Task CheckTimeInEntityTable()
        {
            var meals = await _repository.GetDailyMealsAsync();
            var lastMeal = meals
                .OrderBy(m => m.TimeOfLastMeal)
                .FirstOrDefault();
            if (lastMeal == null)
            {
                if (lastMeal.TimeOfLastMeal.TimeOfDay > DateTime.Now.TimeOfDay)
                {
                    await _repository.ClearTable();
                }
            }
            if (lastMeal.TimeOfLastMeal.TimeOfDay > DateTime.Now.TimeOfDay)
            {
                await _repository.ClearTable();
            }

        }
    }
}

