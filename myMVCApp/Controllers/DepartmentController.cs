using myMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myMVCApp.ViewModels;

namespace myMVCApp.Controllers
{
    public class DepartmentController : Controller
    {
        private ApplicationDbContext _context;

        public DepartmentController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }

        // GET: Department
        public ActionResult Index()
        {
            List<Department> departments = _context.Departments.ToList();
            if (departments == null)
                return HttpNotFound();
            return View(departments);
        }

        public ActionResult New()
        {
            var viewModel = new DepartmentFormViewModel
            {
                Department = new Department()
            };

            return View("DepartmentForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Department department)
        {
            // Save is called by DepartmenFormView
            if (!ModelState.IsValid)
            {
                var viewModel = new DepartmentFormViewModel
                {
                    Department = department
                };

                return View("EmployeeForm", viewModel);
            }

            if (department.DepartmentId == 0)
                _context.Departments.Add(department);
            else
            {
                // Update case...
                var departmentInDb = _context.Departments.Single(d => d.DepartmentId == department.DepartmentId);
                departmentInDb.Name = department.Name;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Department");
        }

        public ActionResult Edit(int departmentId)
        {
            var department = _context.Departments.SingleOrDefault(d => d.DepartmentId == departmentId);

            if (department == null)
                return HttpNotFound();

            var viewModel = new DepartmentFormViewModel
            {
                Department = department
            };

            return View("DepartmentForm", viewModel);
        }

        [HttpPost]  //Goes only with Post request
        public ActionResult Delete(int departmentId) // The employeeId is passed by View
        {
            // Get department from db for given id.
            var departmentInDb = _context.Departments.SingleOrDefault(d => d.DepartmentId == departmentId);
            // Check for existence of object.
            if (departmentInDb == null)
                return HttpNotFound();
            //Remove from memory and save to DB...
            _context.Departments.Remove(departmentInDb);
            _context.SaveChanges();

            return RedirectToAction("Index", "Department");
        }
    }
}