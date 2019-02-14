using System;

namespace ToDoApp.Core.Interfaces
{
    /// <summary>
    /// Агрегация всех репозитриев
    /// </summary>
    public interface IUnitOfWork:IDisposable
    {
        ITodoItemRepository TodoItemRepository { get; }
        IUserRepository UserRepository { get; }
    }
}
