using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicController.Identity.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicController.Identity.IdentityConfirgration
{
    internal sealed class ApplicationUserConfigration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasOne(s => s.ApprovedByUser)
            .WithMany()
            .HasForeignKey(s => s.ApprovedBy).OnDelete(DeleteBehavior.Restrict).IsRequired(false);
        }
    }
}
