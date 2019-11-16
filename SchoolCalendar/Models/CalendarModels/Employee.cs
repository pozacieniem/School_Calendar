using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolCalendar.Models.CalendarModels
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Imię")]
        public string Name { get; set; }

        public int JobPositionId { get; set; }

        public JobPosition JobPosition { get; set; }

        [Display(Name = "Nazwa placówki")]
        public int SchoolId { get; set; }

        public School School { get; set; }
    }
}