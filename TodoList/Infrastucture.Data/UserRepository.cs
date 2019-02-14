using System.Collections.Generic;
using System.Linq;
using LinqToDB.Data;
using ToDoApp.Core.Domain;
using ToDoApp.Core.Interfaces;

namespace ToDoApp.Infrastructure.Linq2DbData
{
    public class UserRepository:IUserRepository
    {
        private readonly DataConnection _connection;

        public UserRepository(DataConnection dataConnection)
        {
            _connection = dataConnection;
        }

        public IEnumerable<User> GetAll()
        {
            return _connection.GetTable<POCO.User>()
                .Select(s => new User() {Id = s.Id, Password = s.Password, Login = s.Login});
        }

        public User Get(int id)
        {
            var user = _connection.GetTable<POCO.User>().FirstOrDefault(s => s.Id == id);
            if (user == null)
            {
                return null;
            }

            return new User()
            {
                Id = user.Id,
                Login = user.Login,
                Password = user.Password
            };
        }

        public void Create(User item)
        {
            throw new System.NotImplementedException();
        }

        public void Update(User item)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
