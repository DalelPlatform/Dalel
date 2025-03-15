using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Restaurant.Enums;
using Models.User;

namespace Models.Restaurant
{
    public class RestaurantReervation
    {
        public int Id { get; set; }
        public string Comments { get; set; }

        public float Rating { get; set; }
        public DateTime ModificationDateTime { get; set; }

        public string TableNumber { get; set; }

        public StatusOfReervations ReervationStatus { get; set; }

        public int RestaurantId { get; set; } //fk

        public string ClientId { get; set; }//fk


        //Relations : 
        public virtual Restaurant Restaurant { get; set; }
        public virtual Client Client {  get; set; }           
    }

    public class RestaurantReervationConfiguration : IEntityTypeConfiguration<RestaurantReervation>
    {
        public void Configure(EntityTypeBuilder<RestaurantReervation> builder)
        {
            builder.HasKey(restreervations => restreervations.Id);
            builder.Property(restreervations => restreervations.ModificationDateTime).HasDefaultValue("GETDATE()");
            builder.Property(restreervations => restreervations.TableNumber).HasColumnType("NVARCHAR(100)");
            builder.Property(restreervations => restreervations.ReervationStatus).HasDefaultValue("Panding");
            builder.Property(restreervations => restreervations.Comments).HasColumnType("NVARCHAR(max)");



            





        }
    }
}
