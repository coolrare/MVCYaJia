using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCYaJia.Models;

namespace MVCYaJia.Controllers
{
    public class OrderLinesController : Controller
    {
        private FabricsEntities db = new FabricsEntities();

        [ChildActionOnly]
        public ActionResult Index(int id)
        {
            var orderLine = db.OrderLine.Where(p => p.ProductId == id).Include(o => o.Order).Include(o => o.Product).Take(10);
            return View(orderLine.ToList());
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
