using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Employee.Business.DataFacade;
using Employee.Business.Models;
using System.ComponentModel.DataAnnotations;
using EmployeeRepoMVC.Infrastructure;

namespace EmployeeRepoMVC.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeFacade facade = new EmployeeFacade();
        // GET: Employee
        [CustomSessionCheck]
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult GetEmployees()
        {
            EmployeeFacade facade = new EmployeeFacade();
            var employe = facade.GetEmployees();
            var data = new
            {
                total = employe
        };
            return Json(data, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Edit(int? id)
        {
            
            EmployeeVM objVm = facade.GetEmployeeById(Convert.ToInt32(id));
            return View("Edit", objVm);
            
        }
        public ActionResult EditPost(EmployeeVM emp)
        {
            facade.UpdateEmployeeById(emp);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {

            int objVm = facade.DeleteGetEmployeeById(Convert.ToInt32(id));
            return RedirectToAction("Index");
        }
        public ActionResult CreatePost(EmployeeVM emp)
        {
            if (ModelState.IsValid)
            {
                facade.InsertEmployee(emp);
                return RedirectToAction("Index");
            }
            else
                return View("Create",emp);

        }
        public ActionResult Create()
        {
            return View();

        }
    }
}