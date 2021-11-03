using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using TVTProject2.Models.Entities;

namespace TVTProject2.Models.ViewModels
{
    public class AssignPersonVM
    {
        [DisplayName("Project Name")]
        public string Name { get; set; }
        public ICollection<Person> People { get; set; }
        public int ProjectId { get; set; }

    }
}
