using System;
using LinqToDB.Data;
using ToDoApp.Core.Interfaces;

namespace ToDoApp.Infrastructure.Linq2DbData
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Lazy<ITodoItemRepository> _todoItemRepository;
        private readonly Lazy<IUserRepository> _userRepository;

        public UnitOfWork(string connectionString)
        {
            var dataConnection = new DataConnection();
            _todoItemRepository = new Lazy<ITodoItemRepository>(() => new TodoItemRepository(dataConnection));
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(dataConnection));
        }

        public ITodoItemRepository TodoItemRepository
        {
            get { return _todoItemRepository.Value; }
        }

        public IUserRepository UserRepository
        {
            get { return _userRepository.Value; }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}