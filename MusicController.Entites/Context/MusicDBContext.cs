using Microsoft.EntityFrameworkCore;
using MusicController.Entites.EntityConfigration;
using MusicController.Entites.Models;
using MusicController.Entites.SeedData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicController.Entites.Context
{
   public class MusicDBContext : DbContext
    {
        public MusicDBContext(DbContextOptions<MusicDBContext> options)
            : base(options)
        {
         //   Database.EnsureCreated();
        }

        public MusicDBContext()
        {
        }

        public virtual DbSet<Outlet> Outlets { get; set; }
        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<Playlist> Playlists { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
           modelBuilder.ApplyConfiguration(new OutletConfiguration());
           modelBuilder.ApplyConfiguration(new DeviceConfiguration());
           modelBuilder.ApplyConfiguration(new PlaylistEntityConfigration());
           modelBuilder.ApplyConfiguration(new TrackEntityConfigration());
        }
        public Task<int> SaveChangesAsync()
        {
            CallBefore();
            return base.SaveChangesAsync();
        }
        public override int SaveChanges()
        {
            CallBefore();
            return base.SaveChanges();
        }

        private void CallBefore()
        {
            var user = GetUserName();
            var AddedEntities = ChangeTracker.Entries()
                               .Where(E => E.State == EntityState.Added)
                               .ToList();
            if(AddedEntities.GetType().GetProperty("CreatedAt")!=null && AddedEntities.GetType().GetProperty("CreatedAt") != null){
                AddedEntities.ForEach(E =>
                {
                                E.Property("CreatedAt").CurrentValue = DateTime.UtcNow;
                    E.Property("CreatedBy").CurrentValue = user;
                });
            }
            
            var EditedEntities = ChangeTracker.Entries()
                                    .Where(E => E.State == EntityState.Modified).ToList();

            if (AddedEntities.GetType().GetProperty("UpdatedAt") != null && AddedEntities.GetType().GetProperty("UpdatedBy") != null)
            {
                                    
                EditedEntities.ForEach(E =>
                {
                    E.Property("UpdatedAt").CurrentValue = DateTime.UtcNow;
                    E.Property("UpdatedBy").CurrentValue = user;
                });
            }
        }
        private string GetUserName()
        {
            return "Aqeel";
        }
    }
}
