using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Models.User
{
    public class RestaurantOwner
    {
        public string UserId { get; set; } //fk & pk

        //Relations :
        public virtual AppUser AppUser { get; set; }
        public virtual Restaurant.Restaurant Restaurant { get; set; }
    }

    public class RestaurantOwnerConfiguration : IEntityTypeConfiguration<RestaurantOwner>
    {
        public void Configure(EntityTypeBuilder<RestaurantOwner> builder)
        {
            builder.HasKey(RestaurantOwners => RestaurantOwners.UserId);
            builder
                .HasOne(a => a.AppUser)
                .WithOne(a => a.RestaurantOwner)
                .HasForeignKey<RestaurantOwner>(a => a.UserId)
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
