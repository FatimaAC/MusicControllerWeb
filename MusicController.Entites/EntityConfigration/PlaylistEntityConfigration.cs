using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicController.Entites.Models;

namespace MusicController.Entites.EntityConfigration
{
    internal sealed class PlaylistEntityConfigration : IEntityTypeConfiguration<Playlist>
    {
        public void Configure(EntityTypeBuilder<Playlist> builder)
        {
            builder.HasOne(s => s.Outlet)
          .WithMany(g => g.Playlist)
          .HasForeignKey(s => s.OutletId).IsRequired(false);
        }
    }
}
