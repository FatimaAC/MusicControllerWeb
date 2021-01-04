using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicController.Entites.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicController.Entites.EntityConfigration
{
    internal sealed class OutletConfiguration : IEntityTypeConfiguration<Outlet>
    {
        public void Configure(EntityTypeBuilder<Outlet> builder)
        {
        }
    }
}
