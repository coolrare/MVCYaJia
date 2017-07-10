using System;
using System.Web.Mvc;

namespace MVCYaJia.Controllers
{
    public class PrepareViewBagAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewData["T1"] = "TEST";
            filterContext.Controller.ViewBag.T1 = "TEST2";

            base.OnActionExecuting(filterContext);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
    }
}