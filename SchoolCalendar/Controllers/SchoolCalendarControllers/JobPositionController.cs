using SchoolCalendar.Models;
using SchoolCalendar.Models.CalendarModels;
using System.Linq;
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

            return View("JobPositionForm", jobPosition);
        }

        [HttpPost]
        public ActionResult Save(JobPosition jobPosition)
        {
            if (!ModelState.IsValid)
            {
                return View("JobPositionForm", jobPosition);
            }

            if (jobPosition.Id == 0)
            {
                _context.JobPositions.Add(jobPosition);
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "JobPosition");
        }

        public ActionResult Delete(int id)
        {
            var jobPosition = _context.JobPositions.SingleOrDefault(j => j.Id == id);
            _context.JobPositions.Remove(jobPosition);
            _context.SaveChanges();
            return RedirectToAction("Index", "JobPosition");
        }
    }
}