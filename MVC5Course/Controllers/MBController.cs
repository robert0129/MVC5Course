using MVC5Course.Models;
using MVC5Course.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    /// <summary>
    /// Model Binging Exercise
    /// </summary>
    public class MBController : BaseController
    {
        private FabricsEntities db = new FabricsEntities();
        // GET: MV
        public ActionResult Index()
        {
            ViewData["Temp"] = "XXXXXXXXXXXXXXXXXX";

            var clv = new ClientLoginViewModel()
            {
                FirstName = "Robert",
                LastName = "Chen"
            };

            ViewData["clv"] = clv;
            return View();
        }

        public ActionResult MyForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MyForm(ClientLoginViewModel c)
        {
            if (ModelState.IsValid)
            {
                TempData["MyFormData"] = c;
                return RedirectToAction("MyFromResult");             
            }
            return View();
        }

        public ActionResult MyFromResult()
        {
            return View();
        }

        ///
        public ActionResult ProductList()
        {
            var data = db.Product.OrderByDescending( p => p.ProductId).Take(5);
            return View(data);
        }

        public ActionResult BatchUpdate(MBProductsModel[] items)
        {
            if (ModelState.IsValid) {
                foreach (var o in items) {
                    Product product = db.Product.Find(o.ProductId);
                    if (product != null) { 
                    product.ProductName = o.ProductName;
                    product.Price = o.Price;
                    product.Stock = o.Stock;
                    product.ProductId = o.ProductId;
                    }
                }
                db.SaveChanges();
                return RedirectToAction("ProductList");
            }
            return View();
        }

        public ActionResult MyError()
        {
            throw new InvalidOperationException("Error");
            return View();
        }
    }
}