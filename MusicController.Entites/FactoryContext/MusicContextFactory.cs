using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MusicController.Entites.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicController.Entites.FactoryContext
{

    public class MusicDBContextFactory : IDesignTimeDbContextFactory<MusicDBContext>
    {
        public MusicDBContext CreateDbContext(string[] args)
        {
            var connection = "Server=ISBLT-6586\\SQLEXPRESS;Database=MusicControllerDB;Trusted_Connection=True;ConnectRetryCount=0";
            var optionsBuilder = new DbContextOptionsBuilder<MusicDBContext>();
            optionsBuilder.UseSqlServer(connection);
            return new MusicDBContext(optionsBuilder.Options);
        }
    }
}
