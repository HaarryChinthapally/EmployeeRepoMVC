using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EmployeeRepoMVC.Infrastructure
{
    public class CustomSessionCheck : ActionFilterAttribute
    {
       
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                if (HttpContext.Current.User.Identity.Name==null)
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary {
                                { "Controller", "Login" },
                                { "Action", "Login" }
                                    });
                }
            }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (HttpContext.Current.User.Identity.Name == null)
            {
                
            }
        }
    }
}