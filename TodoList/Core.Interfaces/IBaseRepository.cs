using System.Collections.Generic;

namespace ToDoApp.Core.Interfaces
{
    public interface IBaseRepository<T> 
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
