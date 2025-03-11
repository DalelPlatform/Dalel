using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Models.User
{
    public class AspDotNetRoles
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string NormalizedName { get; set; }

        public ICollection<AspDotNetUserRoles> AspDotNetUserRoles { get; set; }
    }

    public class AspDotNetRolesConfiguration : IEntityTypeConfiguration<AspDotNetRoles>
    {
        public void Configure(EntityTypeBuilder<AspDotNetRoles> builder)
        {
            builder.HasKey(userRole => userRole.Id);
            builder.Property(userRole => userRole.Name).HasColumnType("NVARCHAR(50)").HasDefaultValue("empty");
            builder.Property(userRole => userRole.NormalizedName).HasColumnType("NVARCHAR(50)").HasDefaultValue("empty");


            builder.HasMany(usrRoles => usrRoles.AspDotNetUserRoles)
                .WithOne(Roles => Roles.AspDotNetRoles)
                .HasForeignKey(usrRoles => usrRoles.RoleId);
        }
    }
}
