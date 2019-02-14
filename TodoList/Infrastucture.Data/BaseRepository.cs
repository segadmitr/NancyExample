using System.Collections.Generic;
using LinqToDB.Data;
using ToDoApp.Core.Interfaces;

namespace ToDoApp.Infrastructure.Linq2DbData
{
    public class BaseRepository<T>:IBaseRepository<T> where T : class
    {
        private readonly DataConnection _connection;

        public BaseRepository(DataConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<T> GetAll()
        {
            return null;
        }

        public T Get(int id)
        {
            return null;
        }

        public void Create(T item)
        {
            
        }

        public void Update(T item)
        {
           
        }

        public void Delete(int id)
        {
            
        }
    }
}
