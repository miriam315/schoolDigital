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
    public class LessonsService:ILessonsService
    {
        private readonly IRepositoryManager _irepositoryManager;
        public LessonsService(IRepositoryManager irepositoryManager)
        {
            _irepositoryManager = irepositoryManager;
        }


        public Lesson GetLesson(int id)
        {
            return _irepositoryManager.Lessons.GetById(id);
        }

        public IEnumerable<Lesson> GetLessons()
        {
            return _irepositoryManager.Lessons.GetAll();
        }

        public Lesson Add(Lesson lesson)
        {
            _irepositoryManager.Lessons.Add(lesson);
            _irepositoryManager.SaveChanges();
            return lesson;
        }
        public Lesson? GetById(int id)
        {
            return _irepositoryManager.Lessons.GetById(id);
        }

        public Lesson Update(Lesson lesson)
        {
            var exists = _irepositoryManager.Lessons.GetById(lesson.Id);
            if (exists == null)
                return null;

            _irepositoryManager.Lessons.Update(lesson);
            _irepositoryManager.SaveChanges();
            return lesson;
        }

        public void Delete(Lesson lesson)
        {
            _irepositoryManager.Lessons.Delete(lesson);
                _irepositoryManager.SaveChanges();
        }

        public IEnumerable<Lesson> SearchLesson(string name)
        {
            return _irepositoryManager.Lessons.Find(p => p.Title.Contains(name));
        }

    }
}
