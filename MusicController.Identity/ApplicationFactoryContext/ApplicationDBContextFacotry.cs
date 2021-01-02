using Microsoft.EntityFrameworkCore;
using MusicController.Identity.IdentityContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicController.Identity.ApplicationFactoryContext
{
    public class ApplicationDBContextFacotry
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var connection = @"Server=(localdb)\\mssqllocaldb;Database=MusicControleer;Trusted_Connection=True;MultipleActiveResultSets=true";
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connection);
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
