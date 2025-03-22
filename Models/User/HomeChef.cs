using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.HomeChef;

namespace Models.User
{
    public class HomeChef
    {
        public string UserId { get; set; } // fk & pk
        public string FoodSafetyCertification { get; set; }
        public string BankDetails { get; set; }
        public string WorkingHours { get; set; }
        public bool IsDeleted { get; set; }
        public virtual AppUser AppUser { get; set; }
        public virtual ICollection<HomeChefMeal> HomeChefMeal { get; set; }
        public virtual ICollection<HomeChefOrder> HomeChefOrder { get; set; }
    }

    public class HomeChefConfiguration : IEntityTypeConfiguration<HomeChef>
    {
        public void Configure(EntityTypeBuilder<HomeChef> builder)
        {
            builder.HasKey(homechef => homechef.UserId);
            builder.Property(homechef => homechef.FoodSafetyCertification).HasColumnType("NVARCHAR(max)").HasDefaultValue("empty");
            builder.Property(homechef => homechef.BankDetails).HasColumnType("NVARCHAR(50)").HasDefaultValue("empty");
            builder.Property(homechef => homechef.WorkingHours).HasColumnType("NVARCHAR(50)").HasDefaultValue("empty");

            builder
                .HasOne(a => a.AppUser)
                .WithOne(a => a.HomeChef)
                .HasForeignKey<HomeChef>(a => a.UserId);

            //relation between HomeChef & HomeChefMeal (one to many)
            builder.HasMany(homechefmeal => homechefmeal.HomeChefMeal)
                .WithOne(homechef => homechef.HomeChef)
                .HasForeignKey(homechefmeal => homechefmeal.HomeChefId);

            //relation between HomeChef & HomeChefOrder (one to many)
            builder.HasMany(homecheforder => homecheforder.HomeChefOrder)
                .WithOne(homechef => homechef.HomeChef)
                .HasForeignKey(homechefmeal => homechefmeal.HomeChefId);
        }
    }
}
