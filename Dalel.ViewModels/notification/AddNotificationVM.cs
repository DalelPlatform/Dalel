using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels.notification
{
     public class AddNotificationVM
    {
        public string UserId { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
