using System;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    internal class myactionfilterAttribute : ActionFilterAttribute
    {

        /// <summary>
        /// implement filter attribute to redirect url before execute action
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsLocal) {
                filterContext.Result = new RedirectResult("/");
            }

            //base.OnActionExecuting(filterContext);
        }
    }
}