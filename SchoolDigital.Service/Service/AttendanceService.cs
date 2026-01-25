using SchoolDigital.Core;
using SchoolDigital.Core.Entities;
using SchoolDigital.Core.Repositories;
using SchoolDigital.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDigital.Service.Service
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IRepositoryManager _irepositoryManager;

        public AttendanceService(IRepositoryManager irepositoryManager)
        {
            _irepositoryManager = irepositoryManager;
        }

        public IEnumerable<Attendance> GetByLessonId(int lessonId)
        {
            return _irepositoryManager.Attendances.Find(a => a.LessonId == lessonId);
        }

        public Attendance? GetById(int id) => _irepositoryManager.Attendances.GetById(id);

        public Attendance Add(Attendance attendance)
        {
            _irepositoryManager.Attendances.Add(attendance);
            _irepositoryManager.SaveChanges();
            return attendance;
        }

        public Attendance? Update(Attendance attendance)
        {
            var exists = _irepositoryManager.Attendances.GetById(attendance.Id);
            if (exists == null) return null;

            _irepositoryManager.Attendances.Update(attendance);
            _irepositoryManager.SaveChanges();
            return attendance;
        }
    }
}

