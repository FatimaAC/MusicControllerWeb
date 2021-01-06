using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicController.Entites.Models;

namespace MusicController.Entites.EntityConfigration
{
    internal sealed class DeviceConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.HasOne(s => s.Outlet)
            .WithMany(g => g.Devices)
            .HasForeignKey(s => s.OutletId);
        }
    }
}
