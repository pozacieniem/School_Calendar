using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolCalendar.Models.CalendarModels
{
    public class Child
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Imie i nazwisko")]
        public string Name { get; set; }

        [Display(Name = "Data urodzenia")]
        public DateTime? BirthDate { get; set; }

        public string Disability { get; set; }
    }
}