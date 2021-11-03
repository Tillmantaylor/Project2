using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TVTProject2.Models.Entities;

namespace TVTProject2.Models.ViewModels
{
    public class ProjectDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public ICollection<ProjectRole> ProjectRoles { get; set; }
            = new List<ProjectRole>();
    }
}
