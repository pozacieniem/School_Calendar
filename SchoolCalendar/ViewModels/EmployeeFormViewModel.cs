using SchoolCalendar.Models.CalendarModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolCalendar.ViewModels
{
    public class EmployeeFormViewModel
    {
        public Employee Employee { get; set; }
        public IEnumerable<JobPosition> JobPositions { get; set; }
        public IEnumerable<School> Schools { get; set; }
    }
}