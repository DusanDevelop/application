using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using myMVCApp.Models;

namespace myMVCApp.ViewModels
{
    // ViewModel is nothing but a single class that may have multiple models. 
    // It contains multiple models as a property. 
    // It should not contain any method.

    // Strongly typed views are used for rendering specific types of model objects, 
    // instead of using the general ViewData structure.
    public class EmployeeViewModel
    {
        public int DepartmentId { get; set; }
        public IList<Employee> Employees { get; set; }
    }
}