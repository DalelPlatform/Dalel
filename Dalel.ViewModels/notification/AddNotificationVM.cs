using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels.notification
{
     public class AddNotificationVM
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public string ToUserId { get; set; }
        public string FromUserId { get; set; }
        public bool IsToClient { get; set; }
        public string UserId { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
