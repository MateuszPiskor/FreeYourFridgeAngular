using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FreeYourFridge.API.Data;
using FreeYourFridge.API.DTOs;
using FreeYourFridge.API.DTOs.ToDoItemDto;
using FreeYourFridge.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace FreeYourFridge.API.Controllers
{
    [Route("api/[controller]")]
    public class ShoppingListController : ControllerBase
    {
        private readonly IShoppingListRepository _repo;
        private readonly IMapper _mapper;

        public ShoppingListController(IShoppingListRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddToDoItem([FromBody] ToDoItemToAddDto toDoItemToAddDto)
        {
            if (toDoItemToAddDto != null)
            {
                ToDoItem toDoItem = _mapper.Map<ToDoItem>(toDoItemToAddDto);
                toDoItem.IsOnShoppingList = true;

                _repo.Add<ToDoItem>(toDoItem);
                _repo.SaveAll();
               
                return StatusCode(201);
            }
            Response.StatusCode = 400;
            return Content("Naughty");
        }

        [HttpGet]
        public IEnumerable<ToDoItemToListDto> GetToDoItems()
        {
            IEnumerable<ToDoItem> toDoItem = _repo.GetToDoItems();
            IEnumerable<ToDoItemToListDto> toDoItemToList = _mapper.Map<IEnumerable<ToDoItemToListDto>>(toDoItem);
            return toDoItemToList;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoItem(int id)
        {

            if(id != 0){
                _repo.DeleteToDoItem(id);
                return Ok();
            }
            return NotFound();
        }
    }
}