using Microsoft.EntityFrameworkCore;
using MusicController.Common.Constants;
using MusicController.Common.HelperClasses;
using MusicController.Entites.Models;

namespace MusicController.Entites.SeedData
{
    public static class SeedingData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var passwrodandSalt = OutletConstant.DefaultPassword.EncryptPassword();
            modelBuilder.Entity<Outlet>().HasData(
            new Outlet { Id = 1, Name = "Baladna", ImageUrl = "Images/Baladna.png", Password = passwrodandSalt.Item1, Salt = passwrodandSalt.Item2 },
                new Outlet { Id = 2, Name = "Basta", ImageUrl = "Images/Basta.png", Password = passwrodandSalt.Item1, Salt = passwrodandSalt.Item2 },
                new Outlet { Id = 3, Name = "Build It Burger", ImageUrl = "Images/Build It Burger.png", Password = passwrodandSalt.Item1, Salt = passwrodandSalt.Item2 },
                new Outlet { Id = 4, Name = "Debs w Remman", ImageUrl = "Images/Debs w Remman.png", Password = passwrodandSalt.Item1, Salt = passwrodandSalt.Item2 },
                new Outlet { Id = 5, Name = "Gahwetna", ImageUrl = "Images/Gahwetna.png", Password = passwrodandSalt.Item1, Salt = passwrodandSalt.Item2 },
                new Outlet { Id = 6, Name = "Jwala", ImageUrl = "Images/Jwala.png", Password = passwrodandSalt.Item1, Salt = passwrodandSalt.Item2 },
                new Outlet { Id = 7, Name = "Karaki", ImageUrl = "Images/Karaki.png", Password = passwrodandSalt.Item1, Salt = passwrodandSalt.Item2 },
                new Outlet { Id = 8, Name = "La Casa", ImageUrl = "Images/La Casa.png", Password = passwrodandSalt.Item1, Salt = passwrodandSalt.Item2 },
                new Outlet { Id = 9, Name = "Maia", ImageUrl = "Images/Maia.png", Password = passwrodandSalt.Item1, Salt = passwrodandSalt.Item2 },
                new Outlet { Id = 10, Name = "Meatsmith", ImageUrl = "Images/Meatsmith.png", Password = passwrodandSalt.Item1, Salt = passwrodandSalt.Item2 },
                new Outlet { Id = 11, Name = "Mokarabia", ImageUrl = "Images/Mokarabia.png", Password = passwrodandSalt.Item1, Salt = passwrodandSalt.Item2 },
                new Outlet { Id = 12, Name = "Orient Pearl", ImageUrl = "Images/Orient Pearl.png", Password = passwrodandSalt.Item1, Salt = passwrodandSalt.Item2 },
                new Outlet { Id = 14, Name = "Remman Cafe", ImageUrl = "Images/Remman Cafe.png", Password = passwrodandSalt.Item1, Salt = passwrodandSalt.Item2 },
                new Outlet { Id = 15, Name = "Sazeli Logo", ImageUrl = "Images/Sazeli Logo.png", Password = passwrodandSalt.Item1, Salt = passwrodandSalt.Item2 },
                new Outlet { Id = 16, Name = "SMAT", ImageUrl = "Images/SMAT.png", Password = passwrodandSalt.Item1, Salt = passwrodandSalt.Item2 },
                new Outlet { Id = 17, Name = "USTA", ImageUrl = "Images/USTA.png", Password = passwrodandSalt.Item1, Salt = passwrodandSalt.Item2 },
                new Outlet { Id = 18, Name = "USTA Remove", ImageUrl = "Images/USTA.png", Password = passwrodandSalt.Item1, Salt = passwrodandSalt.Item2 }
           );
        }
    }
}
