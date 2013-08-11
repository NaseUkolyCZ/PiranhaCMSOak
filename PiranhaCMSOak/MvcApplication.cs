using Oak;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiranhaCMSOak
{
    public class MvcApplication : System.Web.HttpApplication
    {
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
