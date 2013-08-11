using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PiranhaCMSOak.Support
{
    // http://stackoverflow.com/questions/14540899/mvc4-custom-onactionexecuting-global-asx-filter-is-not-being-triggered
    public class CorrectServerFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            return;
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }
            HttpContextBase ctx = filterContext.HttpContext;

            if (ctx != null && ctx.Request.IsLocal)
            {
                return;
            }

            if (ctx != null)
            {
                string host = ctx.Request.Url.Host;
                if (host != "structureddocument.com")
                {
                    ctx.Response.Redirect("https://structureddocument.com");
                    ctx.Response.End();
                }
            }
        }
    }
}