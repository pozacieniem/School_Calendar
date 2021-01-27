using SchoolCalendar.Models;
using SchoolCalendar.Models.CalendarModels;
using SchoolCalendar.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace SchoolCalendar.Controllers.SchoolCalendarControllers
{
    public class ChildController : Controller
    {
        private ApplicationDbContext _context;

        public ChildController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Child
        public ActionResult Index()
        {
            var children = _context.Children.Include(g => g.Group).Include(s => s.School).ToList();
            return View("Index", children);
        }

        public ActionResult New()
        {
            var schools = _context.Schools.ToList();
            var groups = _context.Groups.ToList();
            var viewModel = new ChildFormViewModel
            {
                Child = new Child(),
                Schools = schools,
                Groups = groups,
            };
            return View("ChildForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Child child)
        {
            if (!ModelState.IsValid)
            {
                return View("SchoolForm", child);
            }

            if (child.Id == 0)
            {
                _context.Children.Add(child);
            }
            else
            {
                var childInDb = _context.Children.Single(s => s.Id == child.Id);
                childInDb.Name = child.Name;
                childInDb.BirthDate = child.BirthDate;
                childInDb.Disability = child.Disability;
                childInDb.DecisionNumber = child.DecisionNumber;
                childInDb.OpinionNumber = child.OpinionNumber;
                childInDb.SchoolId = child.SchoolId;
                childInDb.GroupId = child.GroupId;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Child");
        }

        public ActionResult Edit(int id)
        {
            var child = _context.Children.SingleOrDefault(c => c.Id == id);
            var viewModel = new ChildFormViewModel
            {
                Child = child,
                Schools = _context.Schools.ToList(),
                Groups = _context.Groups.ToList(),
            };

            if (child == null)
            {
                return HttpNotFound();
            }

            return View("ChildForm", viewModel);
        }

        public ActionResult Delete(int id)
        {
            var child = _context.Children.SingleOrDefault(c => c.Id == id);
            _context.Children.Remove(child);
            _context.SaveChanges();
            return RedirectToAction("Index", "Child");
        }
    }
}