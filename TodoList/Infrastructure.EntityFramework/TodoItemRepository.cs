using ToDoApp.Core.Domain;
using ToDoApp.Core.Interfaces;

namespace ToDoApp.Infrastructure.EntityFramework
{
    public class TodoItemRepository :BaseRepository<TodoItem>, ITodoItemRepository
    {
        private readonly TodoListContext _context;

        public TodoItemRepository(TodoListContext context):base(context)
        {
            _context = context;
        }
    }
}