using Models.Enums;
using System.Collections.Generic;

namespace Dalel.ViewModels
{
    public class ServiceProviderProjectDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal ApproximatePrice { get; set; }
        public string PriceUnit { get; set; }
        public string VideoLink { get; set; }
        public List<string> ImagePaths { get; set; }
    }
}