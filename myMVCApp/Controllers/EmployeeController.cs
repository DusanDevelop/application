using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myMVCApp.Models;
using myMVCApp.ViewModels;

namespace myMVCApp.Controllers
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
            base.Dispose(disposing);
        }

        // GET: Employee
        public ActionResult Index(int departmentId) //PK of Department
        {
            //List<Employee> employees = _context.Employees.ToList();
            List<Employee> employees = _context.Employees.Where(emp => emp.DepartmentId == departmentId).ToList();
            if (employees == null)
                return HttpNotFound();
            return View(employees);
        }
              
        public ActionResult Details(int employeeId)
        {
            /*   Employee employee = new Employee()
               {
                   EmployeeId = 101,
               Name = "John",
               Gender = "Male",
               City = "London"
               };*/

            // linq single
            Employee employee = _context.Employees.SingleOrDefault(emp => emp.EmployeeId == employeeId);
            
            if (employee == null)
                return HttpNotFound();

            return View(employee);
        }

        [HttpPost]  //Goes only with Post request
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int employeeId) // The employeeId is passed by View
        {
            // Get customer from db for given id.
            var employeeInDb = _context.Employees.SingleOrDefault(e => e.EmployeeId == employeeId);
            // Check for existence of object.
            if (employeeInDb == null)
                return HttpNotFound();
            //Remove from memory and save to DB...
            _context.Employees.Remove(employeeInDb);
            _context.SaveChanges();

            return RedirectToAction("Index", "Employee", new { employeeInDb.DepartmentId });
        }
            
        public ActionResult New()
        {
            var viewModel = new EmployeeFormViewModel
            {
               
                Employee = new Employee()
                {
                   // DepartmentId = departmentId
                }
            };

            return View("EmployeeForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        /*
            public ActionResult Create(FormCollection formCollection)
            Employee employee = new Employee();
            employee.Name = formCollection["Name"];
            employee.Gender = formCollection["Gender"];
            employee.City = formCollection["City"];
        */
        public ActionResult Save(Employee employee)
        {
            // Save is called by EmployeeFormView
            if (!ModelState.IsValid)
            {
                var viewModel = new EmployeeFormViewModel
                {
                    Employee= employee,
                };

                return View("EmployeeForm", viewModel);
            }

            if (employee.EmployeeId == 0)
                _context.Employees.Add(employee);
            else
            {
                // Update case...
                var employeeInDb = _context.Employees.Single(e => e.EmployeeId == employee.EmployeeId);
                employeeInDb.Name = employee.Name;
                employeeInDb.Gender = employee.Gender;
                employeeInDb.City = employee.City;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Employee", new { employee.DepartmentId });
        }

        public ActionResult Edit(int employeeId)
        {
            var employee = _context.Employees.SingleOrDefault(c => c.EmployeeId == employeeId);

            if (employee == null)
                return HttpNotFound();

            var viewModel = new EmployeeFormViewModel
            {
                Employee = employee
            };

            return View("EmployeeForm", viewModel);
        }
    }
}