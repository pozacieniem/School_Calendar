﻿using SchoolCalendar.Models.CalendarModels;
using System.Collections.Generic;

namespace SchoolCalendar.ViewModels
{
    public class ChildFormViewModel
    {
        public Child Child { get; set; }
        public IEnumerable<School> Schools { get; set; }
        public IEnumerable<Group> Groups { get; set; }
    }
}