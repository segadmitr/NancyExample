using System.Collections.Generic;

namespace ToDoApp.Core.Interfaces
{
    /// <summary>
    /// Базовый интерфейс репозитори
    /// </summary>
    /// <remarks>
    /// Изменения сохраняются автоматически
    /// после выполения команды
    /// </remarks>
    /// <typeparam name="T"></typeparam>
    public interface IBaseRepository<T> 
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
