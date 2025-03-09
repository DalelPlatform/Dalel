using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.User
{
    public class AspNetUserRoles
    {
        public string RoleId {  get; set; } //fk
        public string UserId { get; set; } //fk
    }
}
