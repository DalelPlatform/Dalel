using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Models.User
{
    public class Agency
    {
        public string UserId { get; set; } //fk & pk
        public AspDotNetUsers AspDotNetUsers { get; set; }
    }

    public class AgencyConfiguration : IEntityTypeConfiguration<Agency>
    {
        public void Configure(EntityTypeBuilder<Agency> builder)
        {
            builder.HasKey(Agency => Agency.UserId);


        }
    }
}
