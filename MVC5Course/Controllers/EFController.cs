using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class EFController : Controller
    {
        FabricsEntities db = new FabricsEntities();

        public ActionResult Index()
        {
            var data = db.Product.Where(p => p.ProductName.Contains("White"));
            
            return View(data);
        }

        public ActionResult Create()
        {
            var product = new Product()
            {
                ProductName = "White Cat",
                Active = true,
                Price = 199,
                Stock = 5
            };

            db.Product.Add(product);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var product = db.Product.Find(id);

            // db.OrderLine.Where(p => p.ProductId == id)
            // product.OrderLine

            // 錯誤示範 (以下範例不要抄)
            /*
            foreach (var item in product.OrderLine.ToList())
            {
                db.OrderLine.Remove(item);
                db.SaveChanges();
            }
            */

            db.OrderLine.RemoveRange(product.OrderLine);

            db.Product.Remove(product);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var product = db.Product.Find(id);
            return View(product);
        }

        public ActionResult Update(int id)
        {
            var product = db.Product.Find(id);

            product.ProductName += "!";
            //product.Price = null;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Add20Percent()
        {
            var data = db.Product.Where(p => p.ProductName.Contains("White"));

            foreach (var item in data)
            {
                if (item.Price.HasValue)
                {
                    item.Price = item.Price.Value * 1.2m;
                }
            }

            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}