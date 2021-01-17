using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicController.Common.Constants;
using MusicController.Common.HelperClasses;
using MusicController.Entites.Models;

namespace MusicController.Entites.EntityConfigration
{
    internal sealed class OutletConfiguration : IEntityTypeConfiguration<Outlet>
    {
        public void Configure(EntityTypeBuilder<Outlet> builder)
        {
            builder.Property(e => e.Name).HasMaxLength(OutletConstant.MaxNameLength).IsRequired(true);
            builder.Property(e => e.Description).HasMaxLength(OutletConstant.MaxDescriptionLength);
            builder.Property(e => e.ImageUrl).HasMaxLength(OutletConstant.MaxImageUrlLength).IsRequired(true);
            builder.Property(e => e.Password).HasMaxLength(OutletConstant.MaxPasswordLength).IsRequired(true).HasDefaultValue(PasswordHelper.EncryptPassword(OutletConstant.DefaultPassword));
        }
    }
}
