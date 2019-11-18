using SchoolCalendar.Models;
using SchoolCalendar.Models.CalendarModels;
using SchoolCalendar.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace SchoolCalendar.Controllers.SchoolCalendarControllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext _context;

        public EmployeeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Employee
        public ActionResult Index()
        {
            var employees = _context.Employees.Include(s => s.School).Include(j => j.JobPosition).ToList();

            return View("Index", employees);
        }

        public ActionResult New()
        {
            var viewModel = new EmployeeFormViewModel()
            {
                Employee = new Employee(),
                Schools = _context.Schools.ToList(),
                JobPositions = _context.JobPositions.ToList()
            };
            return View("EmployeeForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var employee = _context.Employees.SingleOrDefault(e => e.Id == id);
            var viewModel = new EmployeeFormViewModel
            {
                Employee = employee,
                Schools = _context.Schools.ToList(),
                JobPositions = _context.JobPositions.ToList()
            };

            if (employee == null)
            {
                return HttpNotFound();
            }

            return View("EmployeeForm", viewModel);
        }

        public ActionResult Save(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View("EmployeeForm", employee);
            }

            if (employee.Id == 0)
            {
                _context.Employees.Add(employee);
            }
            else
            {
                var employeeInDb = _context.Employees.Single(e => e.Id == employee.Id);
                employeeInDb.Name = employee.Name;
                employeeInDb.SchoolId = employee.SchoolId;
                employeeInDb.JobPositionId = employee.JobPositionId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Employee");
        }

        public ActionResult Delete(int id)
        {
            var employee = _context.Employees.SingleOrDefault(e => e.Id == id);
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return RedirectToAction("Index", "Employee");
            //return RedirectToAction
        }
    }
}