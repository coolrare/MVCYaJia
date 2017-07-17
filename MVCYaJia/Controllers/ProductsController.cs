using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCYaJia.Models;
using System.Data.Entity.Validation;

namespace MVCYaJia.Controllers
{
    public class ProductsController : BaseController
    {
        // GET: Products
        public ActionResult Index(bool? ActiveFilter, string ProductNameFilter)
        {
            var data = repo.All();
            if (ActiveFilter.HasValue)
            {
                data = data.Where(p => p.Active == ActiveFilter);
            }

            ViewData.Model = data.Take(10);

            //ViewData.Model = repo.Get前10筆商品資料();

            ViewBag.ActiveFilter = new SelectList(new string[] { "True", "False" });

            var items = repo.All().Select(p => new { p.ProductId, p.ProductName });
            ViewBag.ProductNameFilter = new SelectList(items, "ProductId", "ProductName");

            return View();
        }

        [HttpPost]
        public ActionResult BatchUpdate(ProductBatachUpdateVM[] data)
        {
            // "data[1].Stock"
            if (ModelState.IsValid)
            {
                foreach (var item in data)
                {
                    var aa = repo.Find(item.ProductId);
                    aa.Stock = item.Stock;
                    aa.Active = item.Active;
                }

                repo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }

            ViewData.Model = repo.Get前10筆商品資料();
            return View();
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = repo.Find(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                repo.Add(product);
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = repo.Find(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandleError(View = "Error_DbEntityValidationException",
            ExceptionType = typeof(DbEntityValidationException))]
        public ActionResult Edit(int id, FormCollection form)
        {
            var product = repo.Find(id);

            TryUpdateModel(product, new string[] { "ProductName", "Stock", "Active", "Price" });

            repo.UnitOfWork.Commit();
            return RedirectToAction("Index");

            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = repo.Find(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = repo.Find(id);
            repo.Delete(product);
            repo.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.UnitOfWork.Context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
