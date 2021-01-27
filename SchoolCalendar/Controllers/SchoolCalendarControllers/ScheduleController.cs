using SchoolCalendar.Models;
using System.Web.Mvc;

namespace SchoolCalendar.Controllers.SchoolCalendarControllers
{
    public class ScheduleController : Controller
    {
        private ApplicationDbContext _context;

        public ScheduleController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Scheduler
        public ActionResult Index()
        {
            return View();
        }
    }
}