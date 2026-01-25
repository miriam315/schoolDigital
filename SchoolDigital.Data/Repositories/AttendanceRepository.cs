using Microsoft.EntityFrameworkCore;
using SchoolDigital.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDigital.Data.Repositories
{
    public class AttendanceRepository: Repository<Attendance>
    {
        private readonly DataContext _context;
        private readonly DbSet<Attendance> _dbSet;
        public AttendanceRepository(DataContext context):base(context)
        {
            _context = context;
            _dbSet = context.Set<Attendance>();
        }
    }
}
