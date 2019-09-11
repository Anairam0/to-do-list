using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Repository;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        ITodoListRepository todoListRepository;
        public TodoListController(ITodoListRepository todoListRepository)
        {
            this.todoListRepository = todoListRepository;
        }

        [HttpGet]
        public ActionResult<IList<TodoListItem>> GetAll()
        {
            return todoListRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<TodoListItem> GetById(int id)
        {
            return todoListRepository.Get(id);
        }

        [HttpPost]
        public void CreateItem([FromBody] TodoListItem item)
        {
            todoListRepository.Add(item);
        }
        
        [HttpPut("{id}")]
        public IActionResult EditItem(int id, [FromBody] TodoListItem item)
        {
            todoListRepository.Update(item);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            var result = new ApiResult<int>();

            if(todoListRepository.Delete(id) <= 0)
            {
                result.Message = "Task not Found";
                return NotFound(result);
            }

            result.Message = "Task Deleted Correctly";
            return Ok(result);
        }

        [HttpPut("{id}/Complete")]
        public IActionResult CompleteItem(int id)
        {
            var result = new ApiResult<TodoListItem>();

            TodoListItem itemToComplete = todoListRepository.Get(id);
            if(itemToComplete == null)
            {
                result.Message = "Task not Found";
                return NotFound(result);
            }

            itemToComplete.Status = !itemToComplete.Status;
            todoListRepository.Update(itemToComplete);

            result.Message = "Task Edited Successfully";
            result.Data = itemToComplete;

            return Ok(result);
        }
    }
}
