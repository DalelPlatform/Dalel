using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace Dalel.API.Areas.Agency.UserIdProviders
{
    public class NameUserIdProvider : IUserIdProvider
    {
        public string GetUserId(HubConnectionContext connection)
        {
           
            Console.WriteLine($"[SignalR] Connected UserId: " +
                $"{connection.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value}");


            return connection.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
