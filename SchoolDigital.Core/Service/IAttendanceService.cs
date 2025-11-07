using SchoolDigital.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDigital.Core.Service
{
    public interface IAttendanceService
    {
        public List<Attendance> GetAllTeachers();
        public Attendance GetById(int id);
    }
}
