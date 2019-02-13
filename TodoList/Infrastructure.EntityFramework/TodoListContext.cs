using System.Data.Entity;
using ToDoApp.Core.Domain;

namespace ToDoApp.Infrastructure.EntityFramework
{
    public class TodoListContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }

        static TodoListContext()
        {
            Database.SetInitializer<TodoListContext>(new StoreDbInitializer());
        }
        public TodoListContext(string connectionString)
            : base(connectionString)
        {
        }
    }

    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<TodoListContext>
    {
        protected override void Seed(TodoListContext db)
        {
            
        }
    }
}
