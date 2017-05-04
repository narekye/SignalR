using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Persistent_Connection.Startup))]

namespace Persistent_Connection
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR<>();
        }
    }
}
