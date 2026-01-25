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
    public class RepositoryManager : IRepositoryManager
    {
        private readonly DataContext _context;
        private IRepository<User> _user;
        private IRepository<Lesson> _lesson;
        private IRepository<Material> _material;
        private IRepository<Attendance> _attendance;

        public RepositoryManager(DataContext context)
        {
            _context = context;
        }

        public IRepository<User> Users =>
        _user ??= new Repository<User>(_context);
        public IRepository<Attendance> Attendances =>
      _attendance ??= new Repository<Attendance>(_context);
        public IRepository<Lesson> Lessons =>
      _lesson ??= new Repository<Lesson>(_context);
        public IRepository<Material> Materials =>
      _material ??= new Repository<Material>(_context);

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

