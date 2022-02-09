using EmployeeAttendance.BAL.Models;
using EmployeeAttendance.BAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeAttendance.Controllers
{
    public class HomeController : Controller
    {
        RegistrationService _service;

        public HomeController()
        {
            _service = new RegistrationService();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AdminLogInVM adminLogInVM)
        {
            bool UserDetails = _service.AdminLogin(adminLogInVM);
            if (UserDetails)
            {
                ViewBag.Message = "LogIn Successfully";
                return RedirectToAction("Index","Employee");

            }
            else
            {
                ViewBag.Message = "Invalid Email and Password";
            }
            return View();

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}