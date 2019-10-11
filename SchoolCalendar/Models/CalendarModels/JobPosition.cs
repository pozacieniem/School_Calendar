using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolCalendar.Models.CalendarModels
{
    public class JobPosition
    {
        public int Id { get; set; }

        [Display(Name = "Stanowisko")]
        public string JobPositionName { get; set; }
    }
}