using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MusicController.Identity.Model;

namespace MusicController.Identity.SeedData

{
    public static class IdentitySeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //unique id for identityusers and role 
            const string AdminId = "12bf9f07-c559-4544-9b6f-080e2a1d6549";
            const string DJId = "f410b8f9-c76f-49ac-a674-c2a6994eabda";
            modelBuilder.Entity<IdentityRole>().HasData(

                new IdentityRole
                {
                    Id = AdminId,
                    Name = "Admin",
                    NormalizedName = "admin".ToUpper()
                },
                new IdentityRole
                {
                    Id = DJId,
                    Name = "DJ",
                    NormalizedName = "dj".ToUpper()
                }
                );
            //a hasher to hash the password before seeding the user to the db
            var hasher = new PasswordHasher<ApplicationUser>();
            //Seeding the User to AspNetUsers table
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = AdminId,
                    UserName = "admin@musiccontoller.com",
                    Email = "admin@musiccontoller.com",
                    NormalizedEmail = "admin@musiccontoller.com".ToUpper(),
                    NormalizedUserName = "admin@musiccontoller.com".ToUpper(),
                    EmailConfirmed = true,
                    IsAuthorized = true,
                    PasswordHash = hasher.HashPassword(null, "Admin@123")
                },
                 new ApplicationUser
                 {
                     Id = DJId,
                     UserName = "dj@musiccontoller.com",
                     Email = "dj@musiccontoller.com",
                     NormalizedEmail = "dj@musiccontoller.com".ToUpper(),
                     NormalizedUserName = "dj@musiccontoller.com".ToUpper(),
                     IsAuthorized = true,
                     EmailConfirmed = true,
                     PasswordHash = hasher.HashPassword(null, "Admin@123")
                 }
            );
            //Seeding the relation between our user and role to AspNetUserRoles table
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = AdminId,
                    UserId = AdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = DJId,
                    UserId = DJId
                }
            );
        }
    }
}
