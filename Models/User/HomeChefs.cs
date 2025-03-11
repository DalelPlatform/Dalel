using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Models.User
{
    public class HomeChefs
    {
        public string UserId { get; set; } // fk & pk

        public AspDotNetUsers AspDotNetUsers { get; set; }
    }

    public class HomeChefsConfiguration : IEntityTypeConfiguration<HomeChefs>
    {
        public void Configure(EntityTypeBuilder<HomeChefs> builder)
        {
            builder.HasKey(HomeChef => HomeChef.UserId);


        }
    }
}
