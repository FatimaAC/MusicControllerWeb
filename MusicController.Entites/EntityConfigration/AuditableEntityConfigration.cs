using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicController.Entites.Models;

namespace MusicController.Entites.EntityConfigration
{

    public abstract class AuditableEntityConfigration : IEntityTypeConfiguration<AuditableEntity>
    {
        public void Configure(EntityTypeBuilder<AuditableEntity> builder)
        {

        }
    }
}
