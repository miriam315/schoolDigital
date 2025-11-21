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
        IEnumerable<Attendance> GetUsers();
        Attendance? GetById(int id);

        Attendance Add(Attendance attendance);
        Attendance? Update(int id, Attendance attendance);
        void Delete(Attendance attendance);
    }
}
