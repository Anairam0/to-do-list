using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public void EditItem(int id, [FromBody] TodoListItem item)
        {
            todoListRepository.Update(item);
        }

        [HttpDelete("{id}")]
        public void DeleteItem(int id)
        {
            todoListRepository.Delete(id);
        }
    }
}
