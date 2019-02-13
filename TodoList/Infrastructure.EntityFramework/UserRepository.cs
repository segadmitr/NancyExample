using System.Collections.Generic;
using System.Data.Entity;
using ToDoApp.Core.Domain;
using ToDoApp.Core.Interfaces;

namespace ToDoApp.Infrastructure.EntityFramework
{
    public class UserRepository:IUserRepository
    {
        private readonly TodoListContext _context;

        public UserRepository(TodoListContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User Get(int id)
        {
            return _context.Users.Find(id);
        }

        public void Create(User item)
        {
            _context.Users.Add(item);
        }

        public void Update(User item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var item = _context.Users.Find(id);
            if (item != null)
            {
                _context.Users.Remove(item);
            }
        }
    }
}
