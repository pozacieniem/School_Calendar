using SchoolCalendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolCalendar.Controllers.SchoolCalendarControllers
{
    public class CalendarEventController : Controller
    {
        // GET: CalendarEvent
        public ActionResult Index()
        {
            return View("Index");
        }

        public JsonResult GetEvents()
        {
            {
                using (ApplicationDbContext _context = new ApplicationDbContext())
                {
                    var events = _context.CalendarEvents.ToList();
                    return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
            }
        }
    }
}