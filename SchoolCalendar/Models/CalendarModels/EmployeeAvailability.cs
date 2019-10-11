using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolCalendar.Models.CalendarModels
{
    public class EmployeeAvailability
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Day Day { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}