using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Models.User
{
    public class AspDotNetUserRoles
    {
        public string RoleId {  get; set; } //fk
        public string UserId { get; set; } //fk

        public AspDotNetUsers AspDotNetUsers { get; set; }
        public AspDotNetRoles AspDotNetRoles { get; set; }
    }

    public class AspDotNetUserRolesConfiguration : IEntityTypeConfiguration<AspDotNetUserRoles>
    {
        public void Configure(EntityTypeBuilder<AspDotNetUserRoles> builder)
        {
            //composite key
            builder.HasKey(usrRoles => new {usrRoles.RoleId , usrRoles.UserId});


        }
    }
}
