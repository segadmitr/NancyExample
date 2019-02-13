using System.Collections.Generic;
using ToDoApp.Core.Domain;
using ToDoApp.Core.Interfaces;

namespace ToDoApp.Infrastructure.Linq2DbData
{
    public class TodoItemRepository : ITodoItemRepository
    {
        public IEnumerable<TodoItem> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public TodoItem Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Create(TodoItem item)
        {
            throw new System.NotImplementedException();
        }

        public void Update(TodoItem item)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}