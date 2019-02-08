using ToDoApp.Core.Interfaces;

namespace ToDoApp.Logic.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        public ITodoItemRepository TodoItemRepository { get; }
    }
}