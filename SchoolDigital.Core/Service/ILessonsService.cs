using SchoolDigital.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDigital.Core.Service
{
    public interface ILessonsService
    {
        public List<Lesson> GetAllUsers();
        public Lesson GetById(int id);
    }
}
