using SchoolCalendar.Models;
using SchoolCalendar.Models.CalendarModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolCalendar.Controllers.SchoolCalendarControllers
{
    public class JobPositionController : Controller
    {
        private ApplicationDbContext _context;

        public JobPositionController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: JobPosition
        public ActionResult Index()
        {
            var jobPosition = _context.JobPositions.ToList();
            return View("Index", jobPosition);
        }

        public ActionResult New()
        {
            var jobPosition = new JobPosition();
            return View();
        }
    }
}