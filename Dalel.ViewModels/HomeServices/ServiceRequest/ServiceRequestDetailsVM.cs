using Microsoft.AspNetCore.Http;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public class ServiceRequestDetailsVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ClientId { get; set; }
        public int CategoryServicesId { get; set; }
        public string Address { get; set; }
        public DateTime DueDate { get; set; }
        public string? Image { get; set; }
        public double StartPrice { get; set; }
        public string ClientName { get; set; }

        public string Description { get; set; }
        public DateTime Date { get; set; }
        public RequestStatus Status { get; set; }
    }
}
