using ToDoApp.Core.Domain;

namespace ToDoApp.Core.Interfaces
{
    /// <summary>
    /// Репозитоирий пользователей
    /// </summary>
    public interface IUserRepository: IBaseRepository<User>
    {
    }
}
