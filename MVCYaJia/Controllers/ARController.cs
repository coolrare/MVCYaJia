using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVCYaJia.Controllers
{
    public class ARController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            return PartialView("Index");
        }

        public ActionResult Content1()
        {
            return Content("測試", "text/plain", 
                Encoding.GetEncoding("big5"));
        }

        public string Content2()
        {
            return "Hello";
        }
        public ActionResult Content3()
        {
            return View("GoBack");
        }

        public ActionResult File1()
        {
            return File(Server.MapPath("~/Content/3FC248D17A.jpeg"), "image/jpeg");
        }

        public ActionResult File2()
        {
            return File(Server.MapPath("~/Content/3FC248D17A.jpeg"), "image/jpeg", "美女圖.jpg");
        }

        public ActionResult Json1()
        {
            repo.UnitOfWork.Context.Configuration.LazyLoadingEnabled = false;
            var data = repo.All().Take(5);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}