using Oak;
using PiranhaCMSOak.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PiranhaCMSOak.Controllers
{
    /* Have all your controllers inherit from this if you'd like. */
    public class BaseController : Controller
    {
        protected Users users;

        public Func<string> Email { get; set; }

        /* Nice to have when testing, just redifine these props in your test to stub out session */
        public Func<string, object> GetSession { get; set; }
        public Action<string, object> SetSession { get; set; }

        public BaseController()
        {
            GetSession = key => HttpContext.Session[key];

            SetSession = (key, value) => HttpContext.Session[key] = value;

            users = new Users();

            Email = () => base.User.GetProfile().Email;
        }

        public new JsonResult Json(object model)
        {
            return new DynamicJsonResult(model);
        }

        public new dynamic User()
        {
            return users.ForEmail(Email());
        }

        // http://afana.me/post/aspnet-mvc-internationalization-part-2.aspx
        protected override void ExecuteCore()
        {
            string[] userLanguages;
            string sessionLanguage = Request["Language"] as string;
            string page = Request.Url.AbsolutePath;
            page = page.Replace("/", "").Replace(".aspx", "").ToLower();

            if (sessionLanguage == null || sessionLanguage.Length == 0)
            {
                userLanguages = Request.UserLanguages;
            }
            else
            {
                userLanguages = new string[] { sessionLanguage };
            }
            System.Globalization.CultureInfo ci;
            if (userLanguages.Length > 0)
            {
                try
                {
                    ci = new System.Globalization.CultureInfo(userLanguages[0]);
                    // patch cs&sk -> cs-CZ issue
                    if (ci.LCID == 5 || ci.LCID == 1051) { ci = new System.Globalization.CultureInfo("cs-CZ"); }
                }
                catch (System.Globalization.CultureNotFoundException)
                {
                    ci = System.Globalization.CultureInfo.InvariantCulture;
                }
            }
            else
            {
                ci = System.Globalization.CultureInfo.InvariantCulture;
            }

            System.Threading.Thread.CurrentThread.CurrentCulture = ci;
            System.Threading.Thread.CurrentThread.CurrentUICulture = ci;

            base.ExecuteCore();
        }
    }
}
