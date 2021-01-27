using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolCalendar.Models.CalendarModels
{
    public class School
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Nazwa placówki")]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Nazwa ulicy")]
        public string Street { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Kod pocztowy")]
        public string PostCode { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Nazwa miasta")]
        public string City { get; set; }

        [StringLength(255)]
        [Display(Name = "Numer NIP")]
        public string NIP { get; set; }

        public IList<Employee> Employees { get; set; }
        public IList<Child> Children { get; set; }
        public IList<Group> Groups { get; set; }
    }
}