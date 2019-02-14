using System;
using LinqToDB.Data;
using LinqToDB.DataProvider.SqlServer;
using ToDoApp.Core.Interfaces;

namespace ToDoApp.Infrastructure.Linq2DbData
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Lazy<ITodoItemRepository> _todoItemRepository;
        private readonly Lazy<IUserRepository> _userRepository;
        private DataConnection _connection;
        private bool _disposed;

        public UnitOfWork(string connectionString)
        {
            _connection = SqlServerTools.CreateDataConnection(connectionString, SqlServerVersion.v2012);

            _todoItemRepository = new Lazy<ITodoItemRepository>(() => new TodoItemRepository(_connection));
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(_connection));
        }

        public ITodoItemRepository TodoItemRepository
        {
            get { return _todoItemRepository.Value; }
        }

        public IUserRepository UserRepository
        {
            get { return _userRepository.Value; }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _connection.Dispose();
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