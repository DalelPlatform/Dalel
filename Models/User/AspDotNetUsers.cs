using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Models.User
{
    public class AspDotNetUsers
    {
        public string Id { get; set; }

        public string NationalId { get; set; }

        public string Location { get; set; }

        public string Address { get; set; } 

        public string City { get; set; }

        public string ProfileImg {  get; set; }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string ModificationBy { get; set; }

        public string ModificationDate { get; set; }

        public bool IsDeleted { get; set; }
    }

    public class AspDotNetUsersConfiguration : IEntityTypeConfiguration<AspDotNetUsers>
    {
        public void Configure(EntityTypeBuilder<AspDotNetUsers> builder)
        {
            builder.HasKey (asp => asp.Id);
            builder.Property(asp => asp.NationalId);
                
            
        }
    }
}
