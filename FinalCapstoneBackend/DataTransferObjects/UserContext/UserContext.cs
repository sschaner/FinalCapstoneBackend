using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FinalCapstoneBackend.DataTransferObjects.UserContext
{
    public class UserContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<FavoriteTrail> FavoriteTrails { get; set; }

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
