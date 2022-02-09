using EmployeeAttendance.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAttendance.BAL.Models
{
   public class AdminLogInVM
    {
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ContactNumber { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public Nullable<bool> IsAdmin { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> DepId { get; set; }
        public Nullable<int> ProjId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Project Project { get; set; }
    }
}
