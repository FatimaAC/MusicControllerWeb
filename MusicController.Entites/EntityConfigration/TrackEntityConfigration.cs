using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicController.Common.Constants;
using MusicController.Entites.Models;

namespace MusicController.Entites.EntityConfigration
{
    internal sealed class TrackEntityConfigration : IEntityTypeConfiguration<Track>
    {
        public void Configure(EntityTypeBuilder<Track> builder)
        {
            builder.Property(e => e.TrackURL).HasMaxLength(TrackConstant.MaxTrackURLLength).IsRequired(true);
            builder.Property(e => e.StartTime).IsRequired(true);
            builder.Property(e => e.EndTime).IsRequired(true);

            builder.HasOne(s => s.Playlist)
              .WithMany(g => g.Tracks)
              .HasForeignKey(s => s.PlaylistId).IsRequired(true);
        }
    }
}
