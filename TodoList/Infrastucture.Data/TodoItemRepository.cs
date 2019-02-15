using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using LinqToDB;
using LinqToDB.Data;
using ToDoApp.Core.Interfaces;
using Domain = ToDoApp.Core.Domain;
using Poco = ToDoApp.Infrastructure.Linq2DbData.POCO;

namespace ToDoApp.Infrastructure.Linq2DbData
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly DataConnection _connection;

        public TodoItemRepository(DataConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Domain.TodoItem> GetAll()
        {
            return _connection.GetTable<Poco.TodoItem>().ProjectTo<Domain.TodoItem>();
        }

        public Domain.TodoItem Get(int id)
        {
            var toDoItem = _connection.GetTable<Poco.TodoItem>().FirstOrDefault(s => s.Id == id);
            return toDoItem == null ? null : Mapper.Map<Poco.TodoItem, Domain.TodoItem>(toDoItem);
        }

        public void Create(Domain.TodoItem item)
        {
            var todoItem = Mapper.Map<Domain.TodoItem, Domain.TodoItem>(item);
            _connection.InsertWithIdentity(todoItem);
        }

        public void Update(Domain.TodoItem item)
        {
            var todoItem = Mapper.Map<Domain.TodoItem, Domain.TodoItem>(item);
            _connection.InsertWithIdentity(todoItem);
        }

        public void Delete(int id)
        {
            _connection.GetTable<Poco.User>().Delete(x => x.Id == id);
        }
    }
}