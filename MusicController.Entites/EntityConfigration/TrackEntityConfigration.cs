using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicController.Entites.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicController.Entites.EntityConfigration
{
    internal sealed class TrackEntityConfigration : IEntityTypeConfiguration<Track>
    {
        public void Configure(EntityTypeBuilder<Track> builder)
        {
            builder.HasOne(s => s.Playlist)
          .WithOne(g => g.Track)
          .HasForeignKey<Track>(s => s.PlaylistId).IsRequired(false);
        }
    }
}
