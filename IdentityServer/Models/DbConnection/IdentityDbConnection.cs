using Microsoft.EntityFrameworkCore;
using IdentityServer.Configs;

namespace IdentityServer.Models.DbConnection
{
    public class IdentityDbConnection : DbContext
    {
        public IdentityDbConnection(DbContextOptions<IdentityDbConnection> options)
            : base(options)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(DbConfig.IdentityDbConnectionString);
    }
}