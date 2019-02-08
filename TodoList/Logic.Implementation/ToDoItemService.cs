using System.Collections.Generic;
using ToDoApp.DTO.Items;
using ToDoApp.Logic.Interfaces;

namespace ToDoApp.Logic.Implementation
{
    public class ToDoItemService : IToDoItemService
    {
        public IEnumerable<DtoTodoItem> GetAll()
        {
            //TODO заменить на выбор из репозитория
            yield return new DtoTodoItem()
            {
                Name = "NameTest"
            };
        }

        public DtoTodoItem GetById(int id)
        {
            //TODO заменить на выбор из репозитория
            return new DtoTodoItem()
            {
                Name = "NameTest"
            };
        }
    }
}
