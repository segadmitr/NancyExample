using System.Collections.Generic;
using ToDoApp.DTO.Items;

namespace ToDoApp.Logic.Interfaces
{
    public interface IToDoItemService
    {
        IEnumerable<DtoTodoItem> GetAll();
        DtoTodoItem GetById(int id);
    }
}
