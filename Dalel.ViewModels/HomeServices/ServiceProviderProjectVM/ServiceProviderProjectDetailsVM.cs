using System.Collections.Generic;

namespace Dalel.ViewModels
{
    public class ServiceProviderProjectDetailsVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Images { get; set; } = new List<string>();
        public int Id { get; internal set; }
        public string ProjectImages { get; internal set; }
    }
}