using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Services;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        ITodoListService _todoListService;

        public TodoListController(ITodoListService todoListService)
        {
            _todoListService = todoListService;
        }

        [HttpGet]
        public ActionResult<ApiResult<IList<TodoListItem>>> GetAll()
        {
            var result = new ApiResult<IList<TodoListItem>>();

            result.Data = _todoListService.GetAll();
            result.Message = "Todo List";

            return result;
        }

        [HttpGet("{id}")]
        public ActionResult<ApiResult<TodoListItem>> GetById(Guid id)
        {
            var result = new ApiResult<TodoListItem>();

            result.Data = _todoListService.Get(id);
            if(result.Data == null)
            {
                result.Message = "No Todo find with that Id";
                return NoContent();
            }

            result.Message = "Todo Info";

            return result;
        }

        [HttpPost]
        public IActionResult CreateItem([FromBody] TodoListItem item)
        {
            var result = new ApiResult<TodoListItem>();

            var createdItem = _todoListService.Add(item);

            if (createdItem == null)
            {
                result.Message = "Bad Request";
                return BadRequest(result);
            }

            result.Message = "Task Created Successfully";
            result.Data = createdItem;

            return Ok(result);
        }
        
        [HttpPut("{id}")]
        public IActionResult EditItem(Guid id, [FromBody] TodoListItem item)
        {
            var result = new ApiResult<TodoListItem>();

            var updatedItem = _todoListService.Update(item);
            
            if(updatedItem == null)
            {
                result.Message = "Task not Found";
                return NotFound(result);
            }

            result.Message = "Task Edited Successfully";
            result.Data = updatedItem;

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(Guid id)
        {
            var result = new ApiResult<int>();

            if(_todoListService.Delete(id) == null)
            {
                result.Message = "Task not Found";
                return NotFound(result);
            }

            result.Message = "Task Deleted Correctly";
            return Ok(result);
        }

        [HttpPut("{id}/Complete")]
        public IActionResult CompleteItem(Guid id)
        {
            var result = new ApiResult<TodoListItem>();

            TodoListItem itemToComplete = _todoListService.CompleteTask(id);

            if (itemToComplete == null)
            {
                result.Message = "Task not Found";
                return NotFound(result);
            }

            result.Message = "Task Edited Successfully";
            result.Data = itemToComplete;

            return Ok(result);
        }
    }
}
