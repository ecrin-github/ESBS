using Microsoft.EntityFrameworkCore;
using UserService.Configs;

namespace UserService.Models.DbConnection
{
    public class UserDbConnection : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(DbConfigs.DbConnectionString);
    }
}