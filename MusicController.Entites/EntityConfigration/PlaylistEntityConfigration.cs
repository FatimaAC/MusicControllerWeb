using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicController.Common.Constants;
using MusicController.Entites.Models;

namespace MusicController.Entites.EntityConfigration
{
    internal sealed class PlaylistEntityConfigration : IEntityTypeConfiguration<Playlist>
    {
        public void Configure(EntityTypeBuilder<Playlist> builder)
        {
            builder.Property(e => e.Name).HasMaxLength(PlaylistConstant.MaxNameLength).IsRequired(true);
            builder.Property(e => e.Schedule).HasMaxLength(PlaylistConstant.MaxScheduleLength).IsRequired(true);
        builder.HasOne(s => s.Outlet)
          .WithMany(g => g.Playlist)
          .HasForeignKey(s => s.OutletId).IsRequired(true);
        }
    }
}
