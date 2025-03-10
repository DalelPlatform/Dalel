using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Property
{
    public class PropertyImages
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int PropertyId { get; set; } // fk With Properties
    }
}
