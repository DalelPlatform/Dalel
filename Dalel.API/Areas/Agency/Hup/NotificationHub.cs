using System.Security.Claims;
using Dalel.ViewModels.notification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Dalel.API.Areas.Agency.Hup
{
    public class NotificationHub:Hub
    {
        [Authorize(Roles = "TravelAgencyOwner,Admin")]
        public override async Task OnConnectedAsync()
        {
            string userID = Context.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            Console.WriteLine($"🔗 User connected with ID: {userID} and" +
                $" connection: {Context.ConnectionId}");

            if (!string.IsNullOrEmpty(userID))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, userID);
            }
            await base.OnConnectedAsync();
        }
        //[Authorize(Roles = "TravelAgencyOwner,Admin")]
        //public async Task SendNotification(NotificationDetailsVM Message)
        //{
        //    string userID = Context.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        //    await Clients.All.SendAsync("ReceiveNotification", Message);
        //}

        public async Task SendNotificationToUser(string userId, NotificationDetailsVM message)
        {
            await Clients.Group(userId).SendAsync("ReceiveNotification", message);
        }
    }
}
