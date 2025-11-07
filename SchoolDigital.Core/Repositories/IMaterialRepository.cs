using SchoolDigital.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDigital.Core.Repositories
{
    public interface IMaterialRepository
    {
        public List<Material> GetAllTeachers();
        public Material GetById(int id);
    }
}
