using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAttendance.BAL.Models
{
    public class LogInVM
    { //LogInPage
        public Guid LoginId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }

        //LogInTime

        public int LoginTimeId { get; set; }
        public Nullable<System.TimeSpan> TimeIn { get; set; }
        public Nullable<System.TimeSpan> TimeOut { get; set; }
        public Nullable<System.TimeSpan> TotalTime { get; set; }
        /*       public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }*/

        //UserLogInDetail

        public int UserLoginDetailsId { get; set; }
        /*        public string UserName { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<bool> IsDeleted { get; set; }*/
        public string Password { get; set; }

        public Nullable<bool> IsAdmin { get; set; }

    }
}
