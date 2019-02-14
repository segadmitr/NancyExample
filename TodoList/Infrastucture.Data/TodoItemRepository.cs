using System.Collections.Generic;
using LinqToDB.Data;
using ToDoApp.Core.Domain;
using ToDoApp.Core.Interfaces;

namespace ToDoApp.Infrastructure.Linq2DbData
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly DataConnection _dataConnection;

        public TodoItemRepository(DataConnection dataConnection)
        {
            _dataConnection = dataConnection;
            throw new System.NotImplementedException();
        }

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