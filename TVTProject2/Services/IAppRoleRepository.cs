using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TVTProject2.Models.Entities;

namespace TVTProject2.Services
{
    public interface IAppRoleRepository
    {
        ICollection<AppRole> ReadAll();
        AppRole Create(AppRole appRole);
        AppRole Read(int id);
        void Update(int oldId, AppRole appRole);
        void Delete(int id);
    }
}
