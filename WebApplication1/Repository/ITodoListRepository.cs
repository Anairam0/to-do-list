﻿using Server.Models;
using System;
using System.Collections.Generic;

namespace Server.Repository
{
    public interface ITodoListRepository
    {
        TodoListItem Get(Guid id);

        List<TodoListItem> GetAll();

        Guid Delete(Guid id);

        TodoListItem Add(TodoListItem item);

        TodoListItem Update(TodoListItem item);
    }
}
