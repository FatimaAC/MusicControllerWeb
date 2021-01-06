using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MusicController.Entites.EntityConfigration;
using MusicController.Entites.Models;
using MusicController.Entites.SeedData;
using MusicController.Identity.UserService;
using System;
using System.Threading.Tasks;

namespace MusicController.Entites.Context
{
    public class MusicDBContext : DbContext
    {
        private readonly ICurrentUserService _currentUserService;
        public MusicDBContext(DbContextOptions<MusicDBContext> options, ICurrentUserService currentUserService)
            : base(options)
        {
            _currentUserService = currentUserService;
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
            foreach (EntityEntry<AuditableEntity> entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdatedBy = _currentUserService.UserId;
                        entry.Entity.UpdatedAt = DateTime.UtcNow;
                        break;
                }
            }
        }
    }
}
