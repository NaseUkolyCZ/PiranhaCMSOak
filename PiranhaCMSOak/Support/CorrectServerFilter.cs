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
        string _hostChecked;
        string _urlRequired;

        public CorrectServerFilter(string hostChecked, string urlRequired)
        {
            this._hostChecked = hostChecked;
            this._urlRequired = urlRequired;
        }

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
                if (host.CompareTo(_hostChecked) != 0 )
                {
                    ctx.Response.Redirect(_urlRequired);
                    ctx.Response.End();
                }
            }
        }
    }
}