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
        IEnumerable<Lesson> GetUsers();
        Lesson? GetById(int id);

        Lesson Add(Lesson lesson);
        Lesson? Update(int id, Lesson lesson);
        void Delete(Lesson lesson);
    }
}
