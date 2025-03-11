using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Models.Hotel
{
    public class AspNetUser
    {
        public string Id { get; set; }
        public int NationalID { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ProfileImg { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public string ModificationBy { get; set; }
        public DateTime ModificationDate { get; set; }
        public bool IsDeleted { get; set; }
    }


    //AspNetUser configuration
    public class AspNetUserConfiguration : IEntityTypeConfiguration<AspNetUser>
    {
        public void Configure(EntityTypeBuilder<AspNetUser> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.UserName).HasMaxLength(256);
            builder.Property(u => u.Email).HasMaxLength(256);
            builder.Property(u => u.PhoneNumber).HasMaxLength(50);
        }
    }

}
