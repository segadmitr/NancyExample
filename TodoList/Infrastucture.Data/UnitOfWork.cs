using ToDoApp.Core.Interfaces;

namespace ToDoApp.Infrastructure.Linq2DbData
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ITodoItemRepository todoItemRepository, IUserRepository userRepository)
        {
            TodoItemRepository = todoItemRepository;
            UserRepository = userRepository;
        }

        public ITodoItemRepository TodoItemRepository { get; }
        public IUserRepository UserRepository { get; }
    }
}