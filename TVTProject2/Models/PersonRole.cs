using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TVTProject2.Models.Entities;

namespace TVTProject2.Models
{
    public class PersonRole
    {
        public string Name { get; set; }
        public IEnumerable<string> projectRoles { get; set; }
        public int PersonId { get; set; }
        public int ProjectId { get; set; }
    }
}
