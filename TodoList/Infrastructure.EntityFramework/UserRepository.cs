using ToDoApp.Core.Domain;
using ToDoApp.Core.Interfaces;

namespace ToDoApp.Infrastructure.EntityFramework
{
    public class UserRepository:BaseRepository<User>,IUserRepository
    {
        private readonly TodoListContext _context;

        public UserRepository(TodoListContext context):base(context)
        {
            _context = context;
        }
    }
}
