using Microsoft.EntityFrameworkCore;
using MusicController.Entites.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicController.Entites.SeedData
{
    public static class SeedingData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Outlet>().HasData(
            new Outlet { Id = 1, Name = "Baladna", ImageUrl = "Images/Baladna.png" },
                new Outlet { Id = 2, Name = "Basta", ImageUrl = "Images/Basta.png" },
                new Outlet { Id = 3, Name = "Build It Burger", ImageUrl = "Images/Build It Burger.png" },
                new Outlet { Id = 4, Name = "Debs w Remman", ImageUrl = "Images/Debs w Remman.png" },
                new Outlet { Id = 5, Name = "Gahwetna", ImageUrl = "Images/Gahwetna.png" },
                new Outlet { Id = 6, Name = "Jwala", ImageUrl = "Images/Jwala.png" },
                new Outlet { Id = 7, Name = "Karaki", ImageUrl = "Images/Karaki.png" },
                new Outlet { Id = 8, Name = "La Casa", ImageUrl = "Images/La Casa.png" },
                new Outlet { Id = 9, Name = "Maia", ImageUrl = "Images/Maia.png" },
                new Outlet { Id = 10, Name = "Meatsmith", ImageUrl = "Images/Meatsmith.png" },
                new Outlet { Id = 11, Name = "Mokarabia", ImageUrl = "Images/Mokarabia.png" },
                new Outlet { Id = 12, Name = "Orient Pearl", ImageUrl = "Images/Orient Pearl.png" },
                new Outlet { Id =13 , Name = "Palma", ImageUrl = "Images/Palma.png" },
                new Outlet { Id = 14, Name = "Remman Cafe", ImageUrl = "Images/Remman Cafe.png" },
                new Outlet { Id = 15, Name = "Sazeli Logo", ImageUrl = "Images/Sazeli Logo.png" },
                new Outlet { Id = 16, Name = "SMAT", ImageUrl = "Images/SMAT.png" },
                new Outlet { Id = 17, Name = "USTA", ImageUrl = "Images/USTA.png" }
           );
        }
    }
}
