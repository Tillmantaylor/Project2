using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TVTProject2.Models.Entities;

namespace TVTProject2.Services
{
    public interface IProjectRepository
    {
        ICollection<Project> ReadAll();
        Project Create(Project project);
        Project Read(int id);
        void Update(int oldId, Project project);
        void Delete(int id);
    }
}
