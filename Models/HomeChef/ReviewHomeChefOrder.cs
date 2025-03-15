using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.Restaurant;
using Models.User;

namespace Models.HomeChef
{
    public class ReviewHomeChefOrder
    {
        public int Id { get; set; }

        public string Comments { get; set; }
        public float Rating { get; set; }


        public DateTime ModificationDateTime { get; set; }

        public string ClientId { get; set; } //fk

        public int HomeChefOrderId { get; set; } // fk

        //Relations : 

        public virtual Client Client { get; set; }

        public virtual HomeChefOrder HomeChefOrder { get; set; }

    }

    public class ReviewHomeChefOrderConfiguration : IEntityTypeConfiguration<ReviewHomeChefOrder>
    {
        public void Configure(EntityTypeBuilder<ReviewHomeChefOrder> builder)
        {
            builder.HasKey(reviewhomeorder => reviewhomeorder.Id);
            builder.Property(reviewhomeorder => reviewhomeorder.Comments).HasColumnType("NVARCHAR(max)");


        }
    }


}
