using EmployeeAttendance.DAL.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAttendance.BAL.Models
{
    public class EmployeeVM
    {
        //EmployeeDetail
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [Display(Name ="Contact")]
        public string ContactNumber { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        [Display(Name = "Address")]
        public string EmployeeAddress { get; set; }
        [Display(Name = "Salary")]
        public Nullable<int> EmployeeSalary { get; set; }
        [Display(Name = "Image")]
        public string EmployeeImage { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        [Display(Name = "Department")]
        public Nullable<int> DepId { get; set; }
        [Display(Name = "Project")]
        public Nullable<int> ProjId { get; set; }

        // Department
        public int DeparmentId { get; set; }
        public string DepartmentName { get; set; }
        /* public Nullable<bool> IsDeleted { get; set; }
         public Nullable<System.DateTime> CreatedOn { get; set; }*/

        //Project
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        /*   public Nullable<bool> IsDeleted { get; set; }
           public Nullable<System.DateTime> CreatedOn { get; set; }*/
        public virtual Department Department { get; set; }
        public virtual Project Project { get; set; }
    }
}
