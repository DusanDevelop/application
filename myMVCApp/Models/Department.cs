using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        public string Name { get; set; }

        // Navigation property -> Department has many Employees
        public IList<Employee> Employees { get; set; }
    }
}