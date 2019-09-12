using Server.Models;
using Server.Repository;
using System;
using System.Collections.Generic;

namespace Server.Services
{
    public class TodoListService: ITodoListService
    {
        ITodoListRepository _todoRepository;

        public TodoListService(ITodoListRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public TodoListItem Get(Guid id)
        {
            return _todoRepository.Get(id);
        }

        public List<TodoListItem> GetAll()
        {
            return _todoRepository.GetAll();
        }

        public Guid Delete(Guid id)
        {
            return _todoRepository.Delete(id);
        }

        public TodoListItem Add(TodoListItem item)
        {
            //Filling Defaults
            item.Id = Guid.NewGuid();
            item.Status = false;
            item.DateCreated = DateTimeOffset.Now;
            
            return _todoRepository.Add(item);
        }

        public TodoListItem Update(TodoListItem item)
        {
            item.DateModified = DateTimeOffset.Now;

            return _todoRepository.Update(item);
        }

        public TodoListItem CompleteTask(Guid id)
        {
            TodoListItem itemToComplete = _todoRepository.Get(id);
            if (itemToComplete == null)
            {
                return null;
            }

            itemToComplete.Status = !itemToComplete.Status;
            itemToComplete.DateSolved = DateTimeOffset.Now;

            return _todoRepository.Update(itemToComplete);
        }
    }
}
