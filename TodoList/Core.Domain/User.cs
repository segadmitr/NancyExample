using System.Collections.Generic;

namespace ToDoApp.Core.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public ICollection<TodoItem> TodoItems { get; set; }
    }
}
