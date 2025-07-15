using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public class ReviewPropertiesDetailsVM
    {
        public int Id { get; set; }
        public string Comments { get; set; }
        public float Rating { get; set; }
        
        public DateTime ModificationDateTime { get; set; }
        
        public string PropertyName { get; set; }
        public int PropertyId { get; set; }
        
        public string ClientName { get; set; }
        
        public string ClientId { get; set; }

    }
}
