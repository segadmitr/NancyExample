namespace ToDoApp.Core.Interfaces
{
    public interface IUnitOfWork
    {
        ITodoItemRepository TodoItemRepository { get; }
        IUserRepository UserRepository { get; }
    }
}
