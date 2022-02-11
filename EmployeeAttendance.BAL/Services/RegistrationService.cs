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
            if (employeeVM != null)
            {
                employeeDetail.EmployeeId = new int();
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


                UserLoginDetail userDetails = new UserLoginDetail();
                userDetails.UserLoginDetailsId = employeeDetail.EmployeeId;
                userDetails.UserName = employeeDetail.FirstName + employeeDetail.ContactNumber.Substring(employeeDetail.ContactNumber.Length - 4);
                userDetails.Password = employeeDetail.LastName +"@"+ employeeDetail.DateOfBirth.Value.ToString("dd");
                userDetails.CreatedOn = DateTime.Now;
                userDetails.IsDeleted = false;
                userDetails.IsAdmin = true;
                _context.UserLoginDetails.Add(userDetails);
                _context.SaveChanges();

                result = true;
            }
            return result;
        } 

        public List<EmployeeVM> FindData(string Search)
        {
           List<EmployeeVM >employee = new List<EmployeeVM>();
            if(Search != null)
            {
               
                var findData = _context.EmployeeDetails.Where(x => x.FirstName.Contains(Search)).ToList();
                foreach (var list in findData)
                {
                    EmployeeVM employeeVM = new EmployeeVM();
                    employeeVM.EmployeeId = list.EmployeeId;
                    employeeVM.FirstName = list.FirstName;
                    employeeVM.LastName = list.LastName;
                    employeeVM.Email = list.Email;
                    employeeVM.ContactNumber = list.ContactNumber;
                    employeeVM.DateOfBirth = list.DateOfBirth;
                    employeeVM.EmployeeAddress = list.EmployeeAddress;
                    employeeVM.EmployeeSalary = list.EmployeeSalary;
                    employeeVM.EmployeeImage = list.EmployeeImage;
                    employeeVM.IsDeleted = false;
                    employeeVM.CreatedOn = DateTime.Now;
                    employeeVM.DepId = list.DepId;
                    employeeVM.ProjId = list.ProjId;
                    employeeVM.DepartmentName = list.Department.DepartmentName;
                    employeeVM.ProjectName = list.Project.ProjectName;
                    employee.Add(employeeVM);
                }
            }
            return employee;
        }
        public EmployeeVM EditEmployeeData(int? ID)
        {
            EmployeeVM employee = new EmployeeVM();
            if(ID !=null)
            {
              var employeeDetail= _context.EmployeeDetails.FirstOrDefault(x => x.EmployeeId == ID && x.IsDeleted == false);
                employee.EmployeeId = employeeDetail.EmployeeId;
                employee.FirstName = employeeDetail.FirstName;
                employee.LastName = employeeDetail.LastName;
                employee.Email = employeeDetail.Email;
                employee.ContactNumber = employeeDetail.ContactNumber;
                employee.DateOfBirth = employeeDetail.DateOfBirth;
                employee.EmployeeAddress = employeeDetail.EmployeeAddress;
                employee.EmployeeSalary = employeeDetail.EmployeeSalary;
                employee.EmployeeImage = employeeDetail.EmployeeImage;
                employee.IsDeleted = false;
                employee.CreatedOn = DateTime.Now;
                employee.DepId = employeeDetail.DepId;
                employee.ProjId = employeeDetail.ProjId;

            }
            return employee;
        }
        public bool UpdateEmployeeList(EmployeeVM employeeVM)
        {
            bool result = true;
           EmployeeDetail employeeDetail = _context.EmployeeDetails.Where(x => x.EmployeeId == employeeVM.EmployeeId).FirstOrDefault();
            if (employeeDetail != null)
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
                employeeDetail.ProjId = employeeVM.ProjId; ;
                _context.Entry(employeeDetail).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

            }
            return result;
        }
        public bool DeleteData(int id)
        {
            bool result = true;
           EmployeeDetail employeeDetail= _context.EmployeeDetails.Where(x => x.EmployeeId == id).FirstOrDefault();
            if(employeeDetail !=null)
            {
                employeeDetail.IsDeleted = true;
                _context.SaveChanges();
            }
            return result;
        }


    }
}
