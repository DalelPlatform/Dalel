using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public class ChatVM
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public string ServiceProviderId { get; set; }
        public DateTime LastMessageAt { get; set; }
        public List<ServiceQuariesDetailsVM> Messages { get; set; }
    }
}
