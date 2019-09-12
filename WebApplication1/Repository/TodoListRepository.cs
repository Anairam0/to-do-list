using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.Repository
{
    public class TodoListRepository : ITodoListRepository
    {
        private readonly IList<TodoListItem> items = new List<TodoListItem>();

        public TodoListItem Get(Guid id)
        {
            if (id != Guid.Empty)
            {
                return items.SingleOrDefault(e => e.Id == id);
            }
            else
            {
                return null;
            }
        }

        public List<TodoListItem> GetAll()
        {
            return items.ToList();
        }

        public Guid Delete(Guid id)
        {
            if (id != Guid.Empty)
            {
                var item = items.SingleOrDefault(e => e.Id == id);

                items.Remove(item);

                return item.Id;
            }
            else
            {
                return Guid.Empty;
            }
        }

        public TodoListItem Add(TodoListItem item)
        {
            if (item == null || item.Id != Guid.Empty)
            {
                items.Add(item);

                return item;
            }
            return null;
        }

        public TodoListItem Update(TodoListItem item)
        {
            if (item == null || item.Id != Guid.Empty)
            {
                var index = items.IndexOf(items.SingleOrDefault(e => e.Id == item.Id));

                items[index] = item;

                return items[index];
            }
            else
            {
                return null;
            }
        }
    }
}