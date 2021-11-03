using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using TVTProject2.Models.Entities;

namespace TVTProject2.Models.ViewModels
{
    public class PersonDetailsVM
    {
        public int Id { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }
        [DisplayName("Last Name")]
        public string Lastname { get; set; }
        public string Email { get; set; }
        public ICollection<ProjectRole> ProjectRoles { get; set; }
        public PersonDetailsVM()
        {
            ProjectRoles = new List<ProjectRole>();
        }
    }
}
