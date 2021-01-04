using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicController.Entites.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicController.Entites.EntityConfigration
{

    public abstract class AuditableEntityConfigration : IEntityTypeConfiguration<AuditableEntity> 
    {
        public void Configure(EntityTypeBuilder<AuditableEntity> builder)
        {

        }
    }
}
