using Microsoft.AspNetCore.SignalR;
namespace Dalel.API.Hubs
{

    public class ChatHub : Hub
    {
        public async Task SendMessage(string senderId, string receiverId, string message, string requestId)
        {
            // Send message to specific user/group based on receiverId or request
            await Clients.Group(requestId).SendAsync("ReceiveMessage", senderId, message);
        }

        public override async Task OnConnectedAsync()
        {
            var requestId = Context.GetHttpContext()?.Request.Query["requestId"];
            if (!string.IsNullOrEmpty(requestId))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, requestId);
            }

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var requestId = Context.GetHttpContext()?.Request.Query["requestId"];
            if (!string.IsNullOrEmpty(requestId))
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, requestId);
            }

            await base.OnDisconnectedAsync(exception);
        }
    }
}