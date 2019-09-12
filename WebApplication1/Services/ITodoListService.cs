using Server.Models;
using System;
using System.Collections.Generic;

namespace Server.Services
{
    public interface ITodoListService
    {
        TodoListItem Get(Guid id);

        List<TodoListItem> GetAll();

        Guid Delete(Guid id);

        TodoListItem Add(TodoListItem item);

        TodoListItem Update(TodoListItem item);

        TodoListItem CompleteTask(Guid id);
    }
}
