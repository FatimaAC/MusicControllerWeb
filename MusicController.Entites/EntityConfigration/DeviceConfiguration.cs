using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicController.Entites.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicController.Entites.EntityConfigration
{
    internal sealed class DeviceConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.HasKey(e => new { e.OutletId, e.DeviceId });
            builder.HasOne(s => s.Outlet)
            .WithMany(g => g.Devices)
            .HasForeignKey(s => s.OutletId);
        }
    }
}
