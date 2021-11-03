using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TVTProject2.Models.Entities;

namespace TVTProject2.Services
{
    public interface IProjectRoleRepository
    {
        ICollection<ProjectRole> ReadAll();
        ProjectRole Read(int id);
        ProjectRole Create(ProjectRole projectRole);
    }
}
