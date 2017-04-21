using System.Collections.Generic;
using Microsoft.AspNet.SignalR;
using Simple_Chat.Models;

namespace Simple_Chat.Hubs
{
    public class ChatHub : Hub
    {
        private static List<User> Users = new List<User>();

        public void Send(string name, string message)
        {
            Clients.All.addMessage(name, message);
        }

        public void Connect()
        {
            
        }
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}