using SchoolCalendar.Models;
using System.Linq;
using System.Web.Mvc;

namespace SchoolCalendar.Controllers.SchoolCalendarControllers
{
    public class GroupController : Controller
    {
        private ApplicationDbContext _context;

        public GroupController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Groups
        public ActionResult Index()
        {
            var group = _context.Groups.ToList();
            var school = _context.Schools.ToList();
            return View("Index", group);
        }

        public ActionResult Edit()
        {
            return View();
        }

        //public ActionResult New()
        //{
        //    var schools = _context.Schools.ToList();
        //    var children = _context.Children.ToList();
        //}

        public ActionResult Delete(int id)
        {
            var group = _context.Groups.SingleOrDefault(g => g.ID.Equals(id));
            _context.Groups.Remove(group);
            _context.SaveChanges();
            return RedirectToAction("Index", "Group");
        }
    }
}