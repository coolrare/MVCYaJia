using System;
using System.Web.Mvc;

namespace MVCYaJia.Controllers
{
    public class CheckKeyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var key = filterContext.HttpContext.Request.QueryString["key"];

            if (key == "123")
            {
                filterContext.Result = new RedirectResult("/Products");
                return;
            }

            filterContext.Controller.ViewBag.T1 = "TEST2";

            base.OnActionExecuting(filterContext);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
    }
}