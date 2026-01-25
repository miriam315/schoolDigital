using SchoolDigital.Core.Entities;
using SchoolDigital.Core.Repositories;
using SchoolDigital.Core.Service;
using SchoolDigital.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDigital.Service.Service
{
    public class MaterialService:IMaterialService
    {

        private readonly IRepositoryManager _irepositoryManager;
        public MaterialService(IRepositoryManager irepositoryManager)
        {
            _irepositoryManager = irepositoryManager;
        }


        public IEnumerable<Material> GetMaterialsByLesson(int lessonId)
        {
            // שימוש בפונקציית ה-Find שמימשנו ב-Repository
            return _irepositoryManager.Materials.Find(m => m.LessonId == lessonId);
        }

        public Material? GetById(int id) => _irepositoryManager.Materials.GetById(id);

        public Material Add(Material material)
        {
            _irepositoryManager.Materials.Add(material);
            _irepositoryManager.SaveChanges();
            return material;
        }

        public Material? Update(Material material)
        {
            var exists = _irepositoryManager.Materials.GetById(material.Id);
            if (exists == null) return null;

            _irepositoryManager.Materials.Update(material);
            _irepositoryManager.SaveChanges();
            return material;
        }

        public void Delete(int id)
        {
            var material = _irepositoryManager.Materials.GetById(id);
            if (material != null)
            {
                _irepositoryManager.Materials.Delete(material);
                _irepositoryManager.SaveChanges();
            }
        }

    }
}
