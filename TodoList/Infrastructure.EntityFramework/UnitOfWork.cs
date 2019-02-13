using System;
using ToDoApp.Core.Interfaces;

namespace ToDoApp.Infrastructure.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Lazy<ITodoItemRepository> _todoItemRepository;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly TodoListContext _context;
        private bool _disposed;


        public UnitOfWork(string connectionString)
        {
            _context = new TodoListContext(connectionString);
            _todoItemRepository = new Lazy<ITodoItemRepository>(() => new TodoItemRepository(_context));
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(_context));
        }

        public ITodoItemRepository TodoItemRepository
        {
            get { return _todoItemRepository.Value; }
        } 

        public IUserRepository UserRepository
        {
            get { return _userRepository.Value; }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}