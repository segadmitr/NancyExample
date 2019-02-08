using ToDoApp.Core.Interfaces;

namespace ToDoApp.Infrastucture.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public ITodoItemRepository TodoItemRepository { get; }
    }
}