using EmployeeAttendance.BAL.Models;
using EmployeeAttendance.BAL.Services;
using EmployeeAttendance.DAL.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;

namespace EmployeeAttendance.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        private readonly RegistrationService _service;
        EmployeeDetailsDBEntities _context;
        public EmployeeController()
        {
            _service = new RegistrationService();
            _context = new EmployeeDetailsDBEntities();
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
        public ActionResult Create(HttpPostedFileBase file, EmployeeVM emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ViewBag.DepartmentList = _service.GetDepartmentList();
                    ViewBag.DesignationList = _service.GetProjectList();

                    string filename = Path.GetFileName(file.FileName);
                    string _filename = DateTime.Now.ToString("yymmssfff") + filename;
                    string extenion = Path.GetExtension(file.FileName);
                    string path = Path.Combine(Server.MapPath("~/images/"), _filename);
                    emp.EmployeeImage = "~/images/" + _filename;
                    if (extenion.ToLower() == ".jpg" || extenion.ToLower() == ".jpeg" || extenion.ToLower() == ".png")
                    {

                        if (file.ContentLength <= 1000000)
                        {
                            bool modal = _service.CreateEmployeeData(emp);

                            file.SaveAs(path);

                            ModelState.Clear();
                            return RedirectToAction(nameof(Index));
                        }

                    }

                }
            }
            catch(Exception ex)
            {
                ExceptionService.SaveException(ex);
            }
            return View();
        }

        //for Searching
        public ActionResult Display(string Search)
        {
            var data = _service.FindData(Search);
            return View(data);
        }
        public ActionResult Edit(Guid? id)
        {

            if (id == null)
                return View();
            ViewBag.DepartmentList = _service.GetDepartmentList();
            ViewBag.ProjectList = _service.GetProjectList();
         EmployeeVM data = _service.EditEmployeeData(id);
            Session["imgPath"] = data.EmployeeImage;
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase file, EmployeeVM emp)
        {
            try 
            { 
           // EmployeeDetail employee = new EmployeeDetail();
            if (ModelState.IsValid)
            {
                //tb_employeeEntities _context = new tb_employeeEntities();
                EmployeeDetail employee = new EmployeeDetail();
              
                if (file != null)
                {
                    string filename = Path.GetFileName(file.FileName);
                    string _filename = DateTime.Now.ToString("yymmssfff") + filename;
                    string extenion = Path.GetExtension(file.FileName);
                    string path = Path.Combine(Server.MapPath("~/images/"), _filename);
                    emp.EmployeeImage = "~/images/" + _filename;
                    if (extenion.ToLower() == ".jpg" || extenion.ToLower() == ".jpeg" || extenion.ToLower() == ".png")
                    {
                        if (file.ContentLength <= 1000000)
                        {
                            ViewBag.DepartmentList = _service.GetDepartmentList();
                            ViewBag.ProjectList = _service.GetProjectList();
                            bool modal = _service.UpdateEmployeeList(emp);

                            string oldImagePath = Request.MapPath(Session["imgPath"].ToString());

                            file.SaveAs(path);
                            if (System.IO.File.Exists(oldImagePath))
                            {
                                System.IO.File.Delete(oldImagePath);
                            }

                            _context.Entry(employee).State = EntityState.Modified;
                         }
                             return RedirectToAction(nameof(Display));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionService.SaveException(ex);
            }
            return View();

        }
        public ActionResult Delete(Guid id)
        {
            try
            {
                bool data = _service.DeleteData(id);
            }
            catch (Exception ex)
            {
                ExceptionService.SaveException(ex);
            }
            return RedirectToAction(nameof(Display));
        }
        public ActionResult Details(Guid? id)
        {
            try
            {
                var EmpoyeeDetail = _service.Detail(id);
                return View(EmpoyeeDetail);
            }
            catch (Exception ex)
            {
                ExceptionService.SaveException(ex);
            }
            return View();            
        }
        
        public ActionResult SendMail()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendMail(EmailVM model)
        {

            using (MailMessage mm = new MailMessage(model.SenderEmail, model.EmailTo))
            {
                mm.Subject = model.Subject;
                mm.Body = model.Body;

                mm.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("singhpalwinder8624@gmail.com", "Purewal@0001");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
            }
            return View();

        }

    }
}