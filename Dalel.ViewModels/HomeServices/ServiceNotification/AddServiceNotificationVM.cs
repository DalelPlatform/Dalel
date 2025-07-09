using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels.HomeServices.ServiceNotification
{
    public  class AddServiceNotificationVM
    {
        public string ServiceProviderId { get; set; }
        public string ClientId { get; set; }
        public string Message { get; set; }
        public int RequestId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
