using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TVTProject2.Models.Entities;
using TVTProject2.Models;

namespace TVTProject2.Models.ViewModels
{
    public class ProjectDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public int ProjectDue { get; set; }
        public IEnumerable<PersonRole> People { get; set; }
        public int ProjectId { get; set; }
        public ICollection<ProjectRole> ProjectRoles { get; set; }
            = new List<ProjectRole>();
    }
}
