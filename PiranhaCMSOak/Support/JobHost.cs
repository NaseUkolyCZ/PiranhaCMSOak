using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace PiranhaCMSOak.Support
{
    // http://haacked.com/archive/2011/10/16/the-dangers-of-implementing-recurring-background-tasks-in-asp-net.aspx
    public class JobHost : IRegisteredObject
    {
        private readonly object _lock = new object();
        private bool _shuttingDown;

        public JobHost()
        {
            HostingEnvironment.RegisterObject(this);
        }

        public void Stop(bool immediate)
        {
            lock (_lock)
            {
                _shuttingDown = true;
            }
            HostingEnvironment.UnregisterObject(this);
        }

        public void DoWork(Action work)
        {
            lock (_lock)
            {
                if (_shuttingDown)
                {
                    return;
                }
                work();
            }
        }
    }
}
