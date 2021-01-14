using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicController.Common.Constants;
using MusicController.Entites.Models;

namespace MusicController.Entites.EntityConfigration
{
    internal sealed class DeviceConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.Property(e => e.DeviceId).HasMaxLength(DeviceConstant.MaxDeviceIdLength).IsRequired(true);
            builder.HasIndex(e => e.DeviceId).IsUnique(true);
            builder.Property(e => e.ApprovedBy).HasMaxLength(DeviceConstant.MaxApprovedByLength);
            builder.Property(e => e.StatusMessage).HasMaxLength(DeviceConstant.MaxStatusMessageLength);
            builder.Property(e => e.DeviceDetail).HasMaxLength(DeviceConstant.MaxDeviceDetailLength);
            builder.HasOne(s => s.Outlet)
            .WithMany(g => g.Devices)
            .HasForeignKey(s => s.OutletId);
        }
    }
}
