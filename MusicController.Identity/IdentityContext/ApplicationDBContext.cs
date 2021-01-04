using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicController.Identity.IdentityConfirgration;
using MusicController.Identity.Model;
using MusicController.Identity.SeedData;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicController.Identity.IdentityContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public ApplicationDbContext()
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ApplicationUserConfigration());
            builder.Seed();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connection = "Server=ISBLT-6586\\SQLEXPRESS;Database=MusicControllerDB;Trusted_Connection=True;ConnectRetryCount=0";
               // var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                var connectionString = connection;
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
   
}
