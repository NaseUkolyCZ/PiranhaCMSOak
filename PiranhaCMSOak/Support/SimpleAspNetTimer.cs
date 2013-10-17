using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PiranhaCMSOak.Support
{
    public static class SimpleAspNetTimer
    {
        private static readonly Timer _timer = new Timer(OnTimerElapsed);
        private static readonly JobHost _jobHost = new JobHost();

        public static Action Work;

        public static void Start()
        {
            _timer.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));
        }

        private static void OnTimerElapsed(object sender)
        {
            _jobHost.DoWork(() => { if ( Work!=null ) Work(); });
        }
    }
}
