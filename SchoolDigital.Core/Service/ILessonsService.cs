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
        IEnumerable<Lesson> GetLessons();
        Lesson? GetById(int id);
        IEnumerable<Lesson> SearchLesson(string name);
        Lesson Add(Lesson lesson);
        Lesson? Update(Lesson lesson);
        void Delete(Lesson lesson);
    }
}
