using System.Collections.Generic;
using System.Data.Entity;
using ToDoApp.Core.Interfaces;

namespace ToDoApp.Infrastructure.EntityFramework
{
    public class BaseRepository<T>:IBaseRepository<T> where T : class
    {
        private readonly TodoListContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(TodoListContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public void Create(T item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }

        public void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _dbSet.Find(id);
            if (item != null)
            {
                _dbSet.Remove(item);
            }

            _context.SaveChanges();
        }
    }
}
