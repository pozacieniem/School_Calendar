using SchoolCalendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SchoolCalendar.Models.CalendarModels;
using System.Data.Entity.Validation;
using SchoolCalendar.ViewModels;

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
            var children = _context.Children.ToList();
            return View("Index", children);
        }

        public ActionResult New()
        {
            var schools = _context.Schools.ToList();
            var viewModel = new ChildFormViewModel
            {
                Child = new Child(),
                Schools = schools
            };
            return View("ChildForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Child child)
        {
            if (!ModelState.IsValid)
                return View("SchoolForm", child);

            if (child.Id == 0)
                _context.Children.Add(child);
            else
            {
                var childInDb = _context.Children.Single(s => s.Id == child.Id);
                childInDb.Name = child.Name;
                childInDb.BirthDate = child.BirthDate;
                childInDb.Disability = child.Disability;
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
                Schools = _context.Schools.ToList()
            };

            if (child == null)
                return HttpNotFound();

            return View("ChildForm", viewModel);
        }
    }
}