using SchoolDigital.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDigital.Core.Repositories
{
    public interface IUserRepository
    {
        User SearchUser(string pas, string name);
        void Delete(int id);
    }
}
