using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TVTProject2.Models.ViewModels
{
    public class AssignRoleVM
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string PersonName { get; set; }
        public decimal HourlyRate { get; set; }
        public IEnumerable<AssignRoleOptions> AssignRoleOptions { get; set; }
        public int PersonId { get; set; }
    }
}
