using Oak;
using Piranha;
using Piranha.Models;
using Piranha.Web;
using Piranha.WebPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PiranhaCMSOak
{
    public class MvcApplication : System.Web.HttpApplication
    {

        protected void _RenderLevelStart(UIHelper ui, StringBuilder str, string cssclass)
        {
        }
        protected void _RenderLevelEnd(UIHelper ui, StringBuilder str, string cssclass)
        {
        }

        protected void _RenderItemStart(Piranha.Web.UIHelper ui, StringBuilder str, Piranha.Models.Sitemap page, bool active, bool activechild)
        {
        }
        protected void _RenderItemEnd(Piranha.Web.UIHelper ui, StringBuilder str, Piranha.Models.Sitemap page, bool active, bool activechild)
        {
        }

        protected string Url(string virtualpath)
        {
            var request = HttpContext.Current.Request;
            return virtualpath.Replace("~/", request.ApplicationPath + (request.ApplicationPath != "/" ? "/" : ""));
        }

        protected string GenerateUrl(ISitemap page)
        {
            if (page != null)
            {
                if (!String.IsNullOrEmpty(page.Redirect))
                {
                    if (page.Redirect.Contains("://"))
                        return page.Redirect;
                    else if (page.Redirect.StartsWith("~/"))
                        return Url(page.Redirect);
                }
                if (page.IsStartpage)
                    return Url("~/");
                return Url("~/" + (!Config.PrefixlessPermalinks ?
                    Piranha.App.Instance.Handlers.GetUrlPrefix("PERMALINK").ToLower() + "/" : "") + page.Permalink.ToLower());
            }
            return "";
        }


        protected void _RenderItemLink(UIHelper ui, StringBuilder str, Piranha.Models.Sitemap page)
        {
            str.AppendLine(String.Format("<a class=\"element\" href=\"{0}\">{1}</a>", GenerateUrl(page),
                        !String.IsNullOrEmpty(page.NavigationTitle) ? page.NavigationTitle : page.Title));
        }

        /*
         * This is what you can have for menu:
         * 
         <header class="bg-dark">
            <div class="navigation-bar dark shadow">
                <div class="navigation-bar-content container">
                    <nav class="navigation-bar dark">
                        <nav class="navigation-bar-content">
                            @UI.Menu(StopLevel: 1)
                            <a href="/Blog" class="element"><span class="icon-blogger"></span> Blog</a>
                        </nav>
                    </nav>
                </div>
            </div>
        </header>
         */


        protected void _Application_Start_CustomMenu()
        {
            Hooks.Menu.RenderLevelStart += new Piranha.Delegates.MenuLevelHook(_RenderLevelStart);
            Hooks.Menu.RenderLevelEnd += new Piranha.Delegates.MenuLevelHook(_RenderLevelEnd);
            Hooks.Menu.RenderItemStart += new Piranha.Delegates.MenuItemHook(_RenderItemStart);
            Hooks.Menu.RenderItemEnd += new Piranha.Delegates.MenuItemHook(_RenderItemEnd);
            Hooks.Menu.RenderItemLink += new Piranha.Delegates.MenuItemLinkHook(_RenderItemLink);
        }

        public MvcApplication()
        {
            DebugBootStrap.Init(this);
        }

        protected void _Application_Start()
        {
            BootStrap.Init();
        }

    }
}
