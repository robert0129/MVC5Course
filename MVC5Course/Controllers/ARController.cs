using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : BaseController
    {
        ProductRepository repo = RepositoryHelper.GetProductRepository();
        // GET: AR
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///  不載入 Layout
        /// </summary>
        /// <returns></returns>
        public ActionResult PartialViewTest()
        {
            return PartialView();
        }

        /// <summary>
        /// 自訂 Content 內容
        /// </summary>
        /// <returns></returns>
        public ActionResult ContentTest()
        {
            return Content("Hello ASP.NET MVC 練習", "text/plain", Encoding.GetEncoding("UTF-8"));
        }

        public ActionResult FileTest()
        {
            var fpath = Server.MapPath("~/Content/image/img.jpg");

            return File(fpath, "image/jpg");
        }

        public ActionResult FileTest2()
        {
            var fpath = Server.MapPath("~/Content/image/img.jpg");
            return File(fpath, "image/jpg", "wolfer.jpg");
        }

        public ActionResult JsonResultTest()
        {
            var db = repo.UnitOfWork.Context;
            db.Configuration.LazyLoadingEnabled = false;
            return Json(repo.GetTopData(5), JsonRequestBehavior.AllowGet);
        }
    }
}