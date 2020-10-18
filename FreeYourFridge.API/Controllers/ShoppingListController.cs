using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using FreeYourFridge.API.Data;
using FreeYourFridge.API.DTOs;
using FreeYourFridge.API.DTOs.ShoppingListItemsDto;
using FreeYourFridge.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FreeYourFridge.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        private readonly IShoppingListRepository _repo;
        private readonly IIngredientRepository _ingredientRepo;
        private readonly IMapper _mapper;

        public ShoppingListController(IShoppingListRepository repo, IMapper mapper, IIngredientRepository ingredientRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _ingredientRepo = ingredientRepo;
        }

        [HttpPost]
        public async Task<IActionResult> AddShoppingListItem([FromBody] ShoppingListItemToAddDto shoppingLitItemToAddDto)
        {
            if (shoppingLitItemToAddDto != null)
            {
                IngredientDto newIngredientDto = await _ingredientRepo.GetIngredientsFromAPI(shoppingLitItemToAddDto.SpoonacularId);
                string image = newIngredientDto.image;
                ShoppingListItem shoppingListItem = _mapper.Map<ShoppingListItem>(shoppingLitItemToAddDto);
                shoppingListItem.IsOnShoppingList = true;
                var userId = User.FindFirst(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
                shoppingListItem.CreatedBy = int.Parse(userId);
                shoppingListItem.Image = image;
                _repo.Add<ShoppingListItem>(shoppingListItem);
                _repo.SaveAll();

                return StatusCode(201);
            }
            Response.StatusCode = 400;
            return Content("Naughty");
        }

        [HttpGet]
        public IEnumerable<ShoppingListItemDto> GetShoopingListItems()
        {
            IEnumerable<ShoppingListItem> ShoppingListItems = _repo.GetShoppingListItems();

            var favouredsFiltered = ShoppingListItems.Where(t =>
               t.CreatedBy == int.Parse(User.FindFirst(claim =>
                   claim.Type == ClaimTypes.NameIdentifier).Value));
            IEnumerable<ShoppingListItemDto> ShoppingListItemToList = _mapper.Map<IEnumerable<ShoppingListItemDto>>(favouredsFiltered);
            return ShoppingListItemToList;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShoppingListItem(int id)
        {
            if (id != 0)
            {
                var userId = int.Parse(User.FindFirst(claim => claim.Type == ClaimTypes.NameIdentifier).Value);
                _repo.DeleteShoppingListItem(id, userId);
                return Ok();
            }
            return NotFound();
        }
    }
}