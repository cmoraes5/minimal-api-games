using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;

namespace MinimalGameApi
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:127.0.0.1,1433;Database=GameDB;User ID=SA;Password=<YourStrong@Passw0rd>;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
