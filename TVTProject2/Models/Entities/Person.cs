using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TVTProject2.Models.Entities
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }
        [StringLength(30)]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(30)]
        public string Lastname { get; set; }
        [Required]
        public string Email { get; set; }
        public ICollection<ProjectRole> ProjectRoles { get; set; } = new List<ProjectRole>();
    }
}
