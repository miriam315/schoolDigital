using SchoolDigital.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDigital.Core.Repositories
{
    public interface IAttendanceRepository:IRepository<Attendance>
    {
  
        Attendance GetById(int lessonid);
        Attendance GetById(int userId, int lessonId);
    }
}
