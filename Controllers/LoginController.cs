using Employee.Business.DataFacade;
using Employee.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EmployeeRepoMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult LoginPost(MVCLogin login)
        {
            LoginFacade logfacade = new LoginFacade();
            if (ModelState.IsValid)
            {
            
               login= logfacade.LoginGetEmployee(login);
                if (login.IsSuccess > 0)
                {
                    FormsAuthentication.SetAuthCookie(login.UserName,false);
                    return RedirectToAction("Index", "Employee");

                }
                
            }
                return RedirectToAction("Login", login);
                
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login", "Login");

        }

    }
}