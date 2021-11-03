using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TVTProject2.Models.Entities
{
    public class AppRole
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(450)]
        public string Description { get; set; }
        public int ProjectRoleId { get; set; }
    }
}
