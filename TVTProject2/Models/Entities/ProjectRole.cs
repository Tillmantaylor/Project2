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

        [Range(8, 100)]
        [Column(TypeName = "decimal(18,4")]
        public decimal HourlyRate { get; set; }
        [ForeignKey("PersonId")]
        public int PersonId { get; set; }
        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; }
        [ForeignKey("AppRoleId")]
        public int AppRoleId { get; set; }
    }
}
