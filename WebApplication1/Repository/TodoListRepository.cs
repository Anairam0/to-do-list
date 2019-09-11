using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Repository
{
    public class TodoListRepository : ITodoListRepository
    {
        private readonly IList<TodoListItem> items = new List<TodoListItem>();

        public TodoListItem Get(int id)
        {
            if (id > 0)
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

        public int Delete(int id)
        {
            if (id > 0)
            {
                var item = items.SingleOrDefault(e => e.Id == id);

                items.Remove(item);

                return item.Id;
            }
            else
            {
                return 0;
            }
        }

        public int Add(TodoListItem item)
        {
            if (item == null || item.Id <= 0)
            {
                items.Add(item);

                return item.Id;
            }
            return 0;
        }

        public int Update(TodoListItem item)
        {
            if (item == null || item.Id <= 0)
            {
                var index = items.IndexOf(items.SingleOrDefault(e => e.Id == item.Id));

                items[index] = item;

                return item.Id;
            }
            else
            {
                return 0;
            }
        }

        //public int UpdateStatus(TodoListItem item)
        //{
        //    var index = items.IndexOf(items.SingleOrDefault(e => e.Id == item.Id));
        //    items[index].Status = !item.Status;

        //    return item.Id;
        //}
    }
}