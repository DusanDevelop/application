using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace myMVCApp.Models
{
    public class Employee
    {
        // Primary Key
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "  Please enter employee's name.")] 
        [StringLength(100)]
        public string Name { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }

        // Foreign Key
        public int DepartmentId { get; set; }

        // Navigation property -> Employee has one Department
        public Department Department { get; set; }
    }
}