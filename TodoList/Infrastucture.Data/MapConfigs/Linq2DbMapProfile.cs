using AutoMapper;
using Domain = ToDoApp.Core.Domain;
using Poco = ToDoApp.Infrastructure.Linq2DbData.POCO;

namespace ToDoApp.Infrastructure.Linq2DbData.MapConfigs
{
    /// <summary>
    /// Настройка сопоставления
    /// доменной логики и классов POCO
    /// </summary>
    /// <remarks>
    /// Использовать в начальной точке приложения
    /// </remarks>
    public class Linq2DbMapProfile:Profile
    {
        public Linq2DbMapProfile()
        {
            CreateMap<Poco.TodoItem, Domain.TodoItem>();
            CreateMap<Poco.User, Domain.User>();
            CreateMap<Domain.TodoItem, Poco.TodoItem>()
                .ForMember(x=>x.User, x=>x.Ignore());
            CreateMap<Domain.User, Poco.User>()
                .ForMember(x=>x.DboTodoItemsdboUsersUserIds, x=>x.Ignore());
        }
    }
}
