using MVCYaJia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCYaJia.Controllers
{
    public class MBController : BaseController
    {
        public ActionResult Index(int id)
        {
            ViewData["T1"] = id;
            ViewBag.T1 = id;

            ViewData.Model = repo.Find(1);

            return View();
        }

        public ActionResult ProductEdit(int id)
        {
            return View(repo.Find(id));
        }

        [HttpPost]
        public ActionResult ProductEdit(int id, Product data)
        {
            return Json(repo.Find(id), JsonRequestBehavior.AllowGet);
        }


    }
}