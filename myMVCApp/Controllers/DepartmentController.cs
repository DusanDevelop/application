using myMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}