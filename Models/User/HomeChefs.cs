using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.HomeChef;

namespace Models.User
{
    public class HomeChefs
    {
        public int Id { get; set; }
        public string FoodSafetyCertification { get; set; }

        public string BankDetails { get; set; }

        public string WorkingHours { get; set; }
        public string UserId { get; set; } // fk & pk


        //Relations : 

        public AspDotNetUsers AspDotNetUsers { get; set; }

        public ICollection<HomeChefMeals> homeChefMeals { get; set; }

        public ICollection<HomeChefOrders> homeChefOrders { get; set; }
    }

    public class HomeChefsConfiguration : IEntityTypeConfiguration<HomeChefs>
    {
        public void Configure(EntityTypeBuilder<HomeChefs> builder)
        {
            builder.HasKey(homechef => homechef.Id);
            builder.Property(homechef => homechef.FoodSafetyCertification).HasColumnType("NVARCHAR(max)").HasDefaultValue("empty");
            builder.Property(homechef => homechef.BankDetails).HasColumnType("NVARCHAR(50)").HasDefaultValue("empty");
            builder.Property(homechef => homechef.WorkingHours).HasColumnType("NVARCHAR(50)").HasDefaultValue("empty");




            //relation between HomeChefs & HomeChefMeals (one to many)
            builder.HasMany(homechefmeal => homechefmeal.homeChefMeals)
                .WithOne(homechef => homechef.homeChefs)
                .HasForeignKey(homechefmeal => homechefmeal.HomeChefId);


            //relation between HomeChefs & HomeChefOrders (one to many)
            builder.HasMany(homecheforder => homecheforder.homeChefOrders)
                .WithOne(homechef => homechef.homeChefs)
                .HasForeignKey(homechefmeal => homechefmeal.HomeChefId);
        }
    }
}
