using EmployeeAttendance.BAL.Models;
using EmployeeAttendance.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAttendance.BAL.Services
{
   public class RegistrationService
    {
        EmployeeAttendenceEntities _context;
        public RegistrationService()
        {
            _context = new EmployeeAttendenceEntities();
        }
        public bool AdminLogin(AdminLogInVM adminLogInVM)
        {
            //bool result = false;
            AdminSignUp login = _context.AdminSignUps.Where(x => x.IsDeleted == false && x.Email == adminLogInVM.Email && x.Password == adminLogInVM.Password && x.IsAdmin == false).FirstOrDefault();
            if (login != null)
            {
                return true;
            }
            else
            {
                return false;
            }
            //return result;
        }
        public List<KeyValueModel<int, string>> GetDepartmentList()
        {
            List<KeyValueModel<int, string>> result = new List<KeyValueModel<int, string>>();
            result = _context.Departments.Where(x => x.IsDeleted == false)
                .Select(x => new KeyValueModel<int, string> { Key = x.DeparmentId, Value = x.DepartmentName })
                .ToList();
            return result;
        }
        public List<KeyValueModel<int, string>> GetProjectList()
        {
            List<KeyValueModel<int, string>> result = new List<KeyValueModel<int, string>>();
            result = _context.Projects.Where(x => x.IsDeleted == false)
                .Select(x => new KeyValueModel<int, string> { Key = x.ProjectId, Value = x.ProjectName })
                .ToList();
            return result;
        }
        public bool CreateEmployeeData(EmployeeVM employeeVM)
        {
            bool result = false;
            EmployeeDetail employeeDetail = new EmployeeDetail();
            if(employeeVM !=null)
            {
                employeeDetail.FirstName = employeeVM.FirstName;
                employeeDetail.LastName = employeeVM.LastName;
                employeeDetail.Email = employeeVM.Email;
                employeeDetail.ContactNumber = employeeVM.ContactNumber;
                employeeDetail.DateOfBirth = employeeVM.DateOfBirth;
                employeeDetail.EmployeeAddress = employeeVM.EmployeeAddress;
                employeeDetail.EmployeeSalary = employeeVM.EmployeeSalary;
                employeeDetail.EmployeeImage = employeeVM.EmployeeImage;
                employeeDetail.IsDeleted = false;
                employeeDetail.CreatedOn = DateTime.Now;
                employeeDetail.DepId = employeeVM.DepId;
                employeeDetail.ProjId = employeeVM.ProjId;
                _context.EmployeeDetails.Add(employeeDetail);
                result = true;

            }
            return result;

        }

    }
}
