using System.Collections.Generic;

namespace Server.Repository
{
    public interface ITodoListRepository
    {
        TodoListItem Get(int id);

        List<TodoListItem> GetAll();

        int Delete(int id);

        int Add(TodoListItem item);

        int Update(TodoListItem item);

        // UpdateStatus(TodoListItem item);
    }
}
