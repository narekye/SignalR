using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Persistent_Connection.Models;

namespace Persistent_Connection.Connection
{
    public class ChatConnection : PersistentConnection
    {
        /// <inheritdoc />
        protected override Task OnConnected(IRequest request, string connectionId)
        {
            Data data = new Data() { Name = "Server message", Message = "Client " + connectionId + " is connected to chat" };
            return Connection.Broadcast(data);
        }
    }
}