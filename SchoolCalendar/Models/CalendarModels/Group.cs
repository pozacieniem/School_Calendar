using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolCalendar.Models.CalendarModels
{
    public class Group
    {
        public int ID { get; set; }

        [Display(Name = "Nazwa grupy")]
        public string GroupName { get; set; }

        //public School School { get; set; }

        public IList<Child> Children { get; set; }
    }
}