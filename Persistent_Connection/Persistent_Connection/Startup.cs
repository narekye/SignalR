using Microsoft.Owin;
using Owin;
using Persistent_Connection.Connection;

[assembly: OwinStartup(typeof(Persistent_Connection.Startup))]

namespace Persistent_Connection
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR<ChatConnection>("/chat");
        }
    }
}
