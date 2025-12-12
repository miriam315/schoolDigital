using SchoolDigital.Core.Entities;
using SchoolDigital.Core.Repositories;
using SchoolDigital.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDigital.Service.Service
{
    public class UserService
    {
        private readonly IRepositoryManager _irepositoryManager;
        public UserService(IRepositoryManager irepositoryManager)
        {
            _irepositoryManager = irepositoryManager;
        }


        public User GetUser(int id)
        {
            return _irepositoryManager.Users.GetById(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _irepositoryManager.Users.GetAll();
        }

        public User CreateUser(User user)
        {
            _irepositoryManager.Users.Add(user);
            _irepositoryManager.SaveChanges();
            return user;
        }

        public User UpdateUser(User user)
        {
            var exists = _irepositoryManager.Users.Exists(user.Id);
            if (!exists)
                return null;

            _irepositoryManager.Users.Update(user);
            _irepositoryManager.SaveChanges();
            return user;
        }

        public bool DeleteUser(int id)
        {
            var deleted = _irepositoryManager.Users.Delete(id);
            if (deleted)
                _irepositoryManager.SaveChanges();
            return deleted;
        }

        public IEnumerable<User> SearchProducts(string name)
        {
            return _irepositoryManager.Users.Find(p => p.Name.Contains(name));
        }

    }
}
