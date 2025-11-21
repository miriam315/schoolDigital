using SchoolDigital.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDigital.Core.Repositories
{
    public interface IRepositoryManager
    {
        IRepository<User> Users { get; }
        IRepository<Attendance> Attendances { get; }
        IRepository<Lesson> Lessons { get; }
        IRepository<Material> Materials { get; }
    }
}
