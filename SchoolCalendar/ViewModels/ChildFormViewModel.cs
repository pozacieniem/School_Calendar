using SchoolCalendar.Models.CalendarModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolCalendar.ViewModels
{
    public class ChildFormViewModel
    {
        public Child Child { get; set; }
        public IEnumerable<School> Schools { get; set; }
    }
}