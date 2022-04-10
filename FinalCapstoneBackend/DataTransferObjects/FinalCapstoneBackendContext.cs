using FinalCapstoneBackend.DataTransferObjects.TrailApi;
using FinalCapstoneBackend.DataTransferObjects.UserContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalCapstoneBackend.DataTransferObjects
{
    public class FinalCapstoneBackendContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Trail> Trails { get; set; }
        public DbSet<FavoriteTrails> FavoriteTrails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);
            var configuration = builder.Build();
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
