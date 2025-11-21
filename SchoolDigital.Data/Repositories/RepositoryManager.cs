using Microsoft.EntityFrameworkCore;
using SchoolDigital.Core.Entities;
using SchoolDigital.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDigital.Data.Repositories
{
    public class RepositoryManager(DataContext context, IRepository<T> Trepository) : IRepositoryManager
    {
        private readonly DataContext _context=context;
        public IRepository<User> Users => Trepository;

        public IRepository<Attendance> Attendances =>Trepository;

        public IRepository<Lesson> Lessons => Trepository;

        public IRepository<Material> Materials => Trepository;
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
