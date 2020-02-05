using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace myMVCApp.Models
{
    /*
     * By default, a relationship will be created when there is a navigation property discovered on a type. 
     * To target an alternate key, additional configuration must be performed using the Fluent API
     */
    public class Department
    {
        // Primary Key
        public int DepartmentId { get; set; }

        // 1.) Decorate properties of your model with data annotations.
        [Required(ErrorMessage = " Please enter department's name")] //Set error msg string..
        [StringLength(100)]
        public string Name { get; set; }

        // Navigation property -> Department has many Employees
        public IList<Employee> Employees { get; set; }
    }
}