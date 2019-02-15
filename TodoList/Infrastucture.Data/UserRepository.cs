using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using LinqToDB;
using LinqToDB.Data;
using ToDoApp.Core.Interfaces;
using Domain = ToDoApp.Core.Domain;
using Poco = ToDoApp.Infrastructure.Linq2DbData.POCO;

namespace ToDoApp.Infrastructure.Linq2DbData
{
    public class UserRepository:IUserRepository
    {
        private readonly DataConnection _connection;

        public UserRepository(DataConnection dataConnection)
        {
            _connection = dataConnection;
        }

        #region IBaseRepository

        public IEnumerable<Domain.User> GetAll()
        {
            return _connection.GetTable<Poco.User>().ProjectTo<Domain.User>();
        }

        public Domain.User Get(int id)
        {
            var user = _connection.GetTable<Poco.User>().FirstOrDefault(s => s.Id == id);
            return user == null ? null : Mapper.Map<Poco.User, Domain.User>(user);
        }

        public void Create(Domain.User item)
        {
            var user = Mapper.Map<Domain.User, Poco.User>(item);
            _connection.InsertWithIdentity(user);
        }

        public void Update(Domain.User item)
        {
            var user = Mapper.Map<Domain.User, Poco.User>(item);
            _connection.Update(user);
        }

        public void Delete(int id)
        {
            _connection.GetTable<Poco.User>().Delete(x => x.Id == id);
        }

        #endregion

        #region IUserRepository

        

        #endregion
    }
}
