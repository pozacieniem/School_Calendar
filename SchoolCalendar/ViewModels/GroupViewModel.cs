using SchoolCalendar.Models.CalendarModels;
using System.Collections.Generic;

namespace SchoolCalendar.ViewModels
{
    public class GroupViewModel
    {
        public Group Group { get; set; }
        public IEnumerable<School> Schools { get; set; }
    }
}