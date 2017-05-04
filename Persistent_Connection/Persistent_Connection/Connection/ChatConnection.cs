using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
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

        /// <inheritdoc />
        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            Data chatdata = JsonConvert.DeserializeObject<Data>(data);
            return Connection.Broadcast(chatdata);
        }

        /// <inheritdoc />
        protected override Task OnDisconnected(IRequest request, string connectionId, bool stopCalled)
        {
            Data chatdata = new Data() { Name = "Server message ", Message = "Client with " + connectionId + " id disconnected" };
            return Connection.Broadcast(chatdata);
        }
    }
}