using Microsoft.AspNetCore.SignalR;

namespace FullStackApp.Api.Hubs
{
    public class SchoolHub : Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
        public async Task SystemOutageActiveStatus()
        {

            await Clients.All.SendAsync("systemOutageStatusUpdate");
        }
    }   
  }
