using Models;
using Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.Repository
{
    public class PropertyOwnerReopsitory : BaseRepository<PropertyOwner>
    {
        public PropertyOwnerReopsitory(DelelContext context) : base(context) { }
    }
}
