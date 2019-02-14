using ToDoApp.Core.Domain;

namespace ToDoApp.Core.Interfaces
{
    /// <summary>
    /// Репозиторий списка задач
    /// </summary>
    public interface ITodoItemRepository:IBaseRepository<TodoItem>
    {
    }
}
