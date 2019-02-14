using System.Collections.Generic;
using LinqToDB.Data;
using ToDoApp.Core.Domain;
using ToDoApp.Core.Interfaces;

namespace ToDoApp.Infrastructure.Linq2DbData
{
    public class UserRepository:IUserRepository
    {
        private readonly DataConnection _dataConnection;

        public UserRepository(DataConnection dataConnection)
        {
            _dataConnection = dataConnection;
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public User Get(int id)
        {
            throw new System.NotImplementedException();
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
