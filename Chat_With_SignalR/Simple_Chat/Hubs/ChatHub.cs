namespace Simple_Chat.Hubs
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNet.SignalR;
    using Models;

    public class ChatHub : Hub
    {
        private static List<User> Users = new List<User>();

        public void Send(string name, string message)
        {
            Clients.All.addMessage(name, message);
        }

        public void Connect(string username)
        {
            var id = Context.ConnectionId;

            if (Users.All(x => x.ConnectionId != id))
            {
                Users.Add(new User() { ConnectionId = id, Name = username });
                Clients.Caller.onConnected(id, username, Users);

                Clients.AllExcept(id).onNewUserConnected(id, username);
            }
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            User item = Users.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (!ReferenceEquals(item, null))
            {
                Users.Remove(item);
                var id = Context.ConnectionId;
                Clients.All.onUserDisconnected(id, item.Name);
            }
            return base.OnDisconnected(stopCalled);
        }

        public void Hello()
        {
            Clients.All.hello();
        }
    }
}