using SchoolDigital.Core.Entities;
using SchoolDigital.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDigital.Data.Repositories
{
   public class UserRepository: IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public List<User> GetAllUsers()
        {
            return _context.users;
        }
        public User GetById(int id)
        {
            var u = _context.users.FirstOrDefault(x => x.Id == id);
            return u;
        }
    }
}
