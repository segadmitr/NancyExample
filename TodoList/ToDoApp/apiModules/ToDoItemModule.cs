using System.Linq;
using Nancy;
using Newtonsoft.Json;
using ToDoApp.Logic.Interfaces;

namespace ToDoApp.apiModules
{
    public class ToDoItemModule:NancyModule
    {
        private readonly IToDoItemService _service;

        public ToDoItemModule(IToDoItemService service):base("todos")
        {
            _service = service;
            Get["/"] = parameters => Response.AsJson(service.GetAll().ToList());
            Get["/{id:int}"] = parametr => JsonConvert.SerializeObject(service.GetById(parametr.Id));
        }
        
    }
}
