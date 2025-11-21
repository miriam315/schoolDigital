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
        IEnumerable<Material> GetUsers();
        Material? GetById(int id);

        Material Add(Material meterial);
        Material? Update(int id, Material meterial);
        void Delete(Material meterial);
    }
}
