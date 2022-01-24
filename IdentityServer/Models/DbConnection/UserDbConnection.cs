using IdentityServer.Models.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IdentityServer.Configs;

namespace IdentityServer.Models.DbConnection
{
    public class UserDbConnection : IdentityDbContext<RmsUser>
    {
        public UserDbConnection(DbContextOptions<UserDbConnection> options)
            : base(options)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(DbConfig.UserDbConnectionString);
    }
}