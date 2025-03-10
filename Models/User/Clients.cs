using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Models.User
{
    public class Clients
    {
        public string UserId { get; set; } //fk & pk

        public AspDotNetUsers AspDotNetUsers { get; set; }
    }

    public class ClientsConfiguration : IEntityTypeConfiguration<Clients>
    {
        public void Configure(EntityTypeBuilder<Clients> builder)
        {
            builder.HasKey(client => client.UserId);


        }
    }
}
