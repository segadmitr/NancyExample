using System.Collections.Generic;
using System.Linq;
using ToDoApp.Core.Interfaces;
using ToDoApp.DTO.Items;
using ToDoApp.Logic.Interfaces;

namespace ToDoApp.Logic.Implementation
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ToDoItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

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
