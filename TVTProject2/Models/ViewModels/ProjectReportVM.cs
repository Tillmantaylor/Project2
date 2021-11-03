using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TVTProject2.Models.ViewModels
{
    public class ProjectReportVM
    {
        [DisplayName("Project Name")]
        public string ProjectName { get; set; }
        [DisplayName("Number of People")]
        public int NumberOfPeople { get; set; }
        [DisplayName("Total Hourly Rate")]
        public decimal TotalHourlyRate { get; set; }
        [DisplayName("Person")]
        public string FullName { get; set; }
        [DisplayName("Project Role")]
        public string Role { get; set; }
        [DisplayName("Hourly Rate")]
        public decimal HourlyRate { get; set; }

    }
}
