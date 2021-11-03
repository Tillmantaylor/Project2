using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TVTProject2.Models.Entities
{
    public class ProjectRole
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(8, 100)]
        [Column(TypeName = "decimal(18,4")]
        public decimal HourlyRate { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int AppRoleId { get; set; }
    }
}
