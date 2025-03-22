using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Enums;

namespace Models.HomeChef
{
    public class HomeChefDelivery
    {
        public int Id { get; set; }
        public string PlatformLogistics { get; set; }

        public bool SelfDelivery { get; set; }

        public StatusOfDelivery DeliveryStatus { get; set; } //enum
        public int HomeChefOrderId { get; set; }//fk
        public virtual HomeChefOrder HomeChefOrder { get; set; }
    }


    public class HomeChefDeliveriesConfiguration : IEntityTypeConfiguration<HomeChefDelivery>
    {
        public void Configure(EntityTypeBuilder<HomeChefDelivery> builder)
        {
            builder.HasKey(homechefdelivery => homechefdelivery.Id);
            builder.Property(homechefdelivery => homechefdelivery.PlatformLogistics).HasColumnType("NVARCHAR(100)").HasDefaultValue("empty");
            builder.Property(homechefdelivery => homechefdelivery.SelfDelivery).HasDefaultValue(true);
            builder.Property(homechefdelivery => homechefdelivery.DeliveryStatus).HasDefaultValue(StatusOfDelivery.Pending);


            builder.HasOne(p => p.HomeChefOrder)
                .WithOne(o => o.HomeChefDelivery)
                .HasForeignKey<HomeChefDelivery>(p => p.HomeChefOrderId)
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
