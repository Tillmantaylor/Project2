using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TVTProject2.Models
{
    public class AssignRole
    {
        public int ProjectId { get; set; }
        public decimal HourlyRate { get; set; }
        public string Role { get; set; }
        public int PersonId { get; set; }
    }

    public class AssignRoleOptions
    {
        public string Name { get; set; }
    }
}
