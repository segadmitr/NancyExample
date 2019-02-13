using System.Collections.Generic;
using ToDoApp.Core.Domain;
using ToDoApp.Core.Interfaces;
using EntityState = System.Data.Entity.EntityState;

namespace ToDoApp.Infrastructure.EntityFramework
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly TodoListContext _context;

        public TodoItemRepository(TodoListContext context)
        {
            _context = context;
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return _context.TodoItems;
        }

        public TodoItem Get(int id)
        {
            return _context.TodoItems.Find(id);
        }

        public void Create(TodoItem item)
        {
            _context.TodoItems.Add(item);
        }

        public void Update(TodoItem item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var item = _context.TodoItems.Find(id);
            if (item != null)
            {
                _context.TodoItems.Remove(item);
            }
        }
    }
}