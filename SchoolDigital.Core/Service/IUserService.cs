using SchoolDigital.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDigital.Core.Service
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User? GetById(int id);

        User Add(User user);
        User? Update(int id, User user);
        void Delete(User user);
       
    }
}
