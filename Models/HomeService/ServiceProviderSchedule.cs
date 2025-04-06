using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Enums;
using Models.User;

namespace Models.HomeService
{
    public class ServiceProviderSchedule
    {
        public int Id { get; set; }
        public WorKDays WorKDay { get; set; }
        public TimeOnly AvailableFrom { get; set; }
        public TimeOnly AvailableTo { get; set; }

        public string ServiceProviderId { get; set; }
        public virtual ServiceProvider ServiceProvider { get; set; }
    }
    public class ServiceProviderScheduleConfigration : IEntityTypeConfiguration<ServiceProviderSchedule>
    {
        public void Configure(EntityTypeBuilder<ServiceProviderSchedule> builder)
        {
            builder.HasOne(s => s.ServiceProvider).WithMany(p => p.Schedules).HasForeignKey(s => s.ServiceProviderId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
