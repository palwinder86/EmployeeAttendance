using EmployeeAttendance.BAL.Models;
using EmployeeAttendance.BAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeAttendance.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        private readonly RegistrationService _service;
        public EmployeeController()
        {
            _service = new RegistrationService();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            ViewBag.DepartmentList = _service.GetDepartmentList();
            ViewBag.ProjectList = _service.GetProjectList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeeVM employeeVM)
        {   
            _service.CreateEmployeeData(employeeVM);
            return RedirectToAction("Index");
        }

        public ActionResult Display(string Search) //for Searching
        {
            var data= _service.FindData(Search);
            return View(data);
        }
      
    }
}