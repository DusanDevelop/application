using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myMVCApp.Models;

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
              
        public ActionResult Details(int id)
        {

            /*   Employee employee = new Employee()
               {
                   EmployeeId = 101,
               Name = "John",
               Gender = "Male",
               City = "London"
               };*/

            // linq single
            Employee employee = _context.Employees.SingleOrDefault(emp => emp.EmployeeId == id);
            
            if (employee == null)
                return HttpNotFound();

            return View(employee);
        }

    }
}