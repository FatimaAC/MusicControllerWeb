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
            var connection = @"Server=ISBLT-6586\\SQLEXPRESS;Database=MusicControllerDB;Trusted_Connection=True;ConnectRetryCount=0";
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connection);
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
