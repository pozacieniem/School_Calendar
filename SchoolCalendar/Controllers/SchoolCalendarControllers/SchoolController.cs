using SchoolCalendar.Models;
using SchoolCalendar.Models.CalendarModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolCalendar.Controllers.SchoolCalendarControllers
{
    public class SchoolController : Controller
    {
        private ApplicationDbContext _context;

        public SchoolController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: School
        public ActionResult Index()
        {
            var school = _context.Schools.ToList();

            return View("Index", school);
        }

        public ActionResult New()
        {
            var school = new School();
            return View("SchoolForm", school);
        }

        public ActionResult Save(School school)
        {
            if (!ModelState.IsValid)
            {
                return View("SchoolForm", school);
            }

            if (school.Id == 0)
            {
                _context.Schools.Add(school);
            }
            else
            {
                var schoolInDb = _context.Schools.Single(s => s.Id == school.Id);
                schoolInDb.Name = school.Name;
                schoolInDb.Street = school.Street;
                schoolInDb.PostCode = school.PostCode;
                schoolInDb.City = school.City;
                schoolInDb.NIP = school.NIP;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "School");
        }

        public ActionResult Edit(int id)
        {
            var school = _context.Schools.SingleOrDefault(s => s.Id == id);

            if (school == null)
                return HttpNotFound();

            return View("SchoolForm", school);
        }

        //public ActionResult Delete(School school)
        //{
        //    _context.Schools.Remove(school);
        //        _context.SaveChanges();

        //    return RedirectToAction("Index", "School");
        //}
        //}
    }
}