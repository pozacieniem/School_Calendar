using System;
using System.ComponentModel.DataAnnotations;

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

        [Display(Name = "Niepełnosprawność")]
        public string Disability { get; set; }

        [Display(Name = "Numer orzeczenia")]
        public string DecisionNumber { get; set; }

        [Display(Name = "Numer opinii")]
        public string OpinionNumber { get; set; }

        public School School { get; set; }

        [Display(Name = "Nazwa placówki")]
        public int SchoolId { get; set; }
    }
}