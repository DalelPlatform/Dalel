using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public class ServiceQuariesDetailsVM
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public int CategoryServicesId { get; set; }
        public string CategoryName { get; set; }
        public string ServiceProviderId { get; set; }
        public string ServiceProviderName { get; set; }
        public string Comment { get; set; }
        public DateTime? CommentDate { get; set; }
    }
}
