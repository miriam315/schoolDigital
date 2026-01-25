using SchoolDigital.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDigital.Core.Service
{
    public interface IMaterialService
    {
        IEnumerable<Material> GetMaterialsByLesson(int lessonId);
        Material? GetById(int id);
        Material Add(Material material);
        Material? Update(Material material);
        void Delete(int id);
    }
}
