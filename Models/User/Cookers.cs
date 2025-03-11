using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Models.User
{
    public class Cookers
    {
        public string UserId { get; set; } //fk & pk


        public AspDotNetUsers AspDotNetUsers { get; set; }
    }

    public class CookersConfiguration : IEntityTypeConfiguration<Cookers>
    {
        public void Configure(EntityTypeBuilder<Cookers> builder)
        {
            builder.HasKey(cooker => cooker.UserId);


        }
    }
}
