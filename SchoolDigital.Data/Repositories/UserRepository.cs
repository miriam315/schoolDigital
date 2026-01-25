using Microsoft.EntityFrameworkCore;
using SchoolDigital.Core.Entities;
using SchoolDigital.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDigital.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly DataContext _context;
        private readonly DbSet<User> _dbSet;
        public UserRepository(DataContext context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<User>();
        }
        public User SearchUser(string pas, string name)
        {
            return _context.users.FirstOrDefault(u => u.Password == pas && u.Name == name);

        }

        public void Delete(int id)
        {
            var user = _dbSet.SingleOrDefault(u => u.Id == id);
            if (user != null)
                user.Status = EStatus.inactive;
            _context.SaveChanges();
        }
    }
}
