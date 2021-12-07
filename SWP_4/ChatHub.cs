using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
namespace SWP_4
{


    [Authorize]
    public class ChatHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            Groups.AddToGroupAsync(Context.ConnectionId, Context.User.Identity.Name);
            return base.OnConnectedAsync();
        }

        public async Task Send(string message, string userName)
        {
            await Clients.All.SendAsync("Receive", message, userName);
        }
        public Task SendMessageToGroup(string receiver, string message)
        //public Task SendMessageToGroup(string sender, string receiver, string message)
        {
            // return Clients.Group(receiver).SendAsync("ReceiveMessage", sender, message);
            string name = Context.User.Identity.Name;

            return Clients.Group(receiver).SendAsync("Receive", receiver, message);
        }
    }
}