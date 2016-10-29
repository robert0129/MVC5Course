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
    public class MBController : Controller
    {
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
    }
}