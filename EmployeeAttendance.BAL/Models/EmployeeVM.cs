using System;
using System.Collections.Generic;
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
        public string ContactNumber { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string EmployeeAddress { get; set; }
        public Nullable<int> EmployeeSalary { get; set; }
        public string EmployeeImage { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> DepId { get; set; }
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

    }
}
