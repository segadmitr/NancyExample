using ToDoApp.Core.Interfaces;

namespace ToDoApp.Infrastucture.Linq2DbData
{
    public class UnitOfWork : IUnitOfWork
    {
        public ITodoItemRepository TodoItemRepository { get; }
        public IUserRepository UserRepository { get; }
    }
}