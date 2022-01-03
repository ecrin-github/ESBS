using ContextService.Models.Rms;
using ContextService.Configs;
using Microsoft.EntityFrameworkCore;

namespace ContextService.Models.DbConnection
{
    public class RmsDbConnection : DbContext
    {
        public RmsDbConnection(DbContextOptions<RmsDbConnection> options) 
            : base(options)
        {
            
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql($"Host={DbConfigs.RmsDbConfigs.Host};Database={DbConfigs.RmsDbConfigs.Database};Username={DbConfigs.RmsDbConfigs.Username};Password={DbConfigs.RmsDbConfigs.Password}");
        
        public DbSet<AccessPrereqType> AccessPrereqTypes { get; set; }
        public DbSet<CheckStatusType> CheckStatusTypes { get; set; }
        public DbSet<DtpStatusType> DtpStatusTypes { get; set; }
        public DbSet<DupStatusType> DupStatusTypes { get; set; }
        public DbSet<LegalStatusType> LegalStatusTypes { get; set; }
        public DbSet<RepoAccessType> RepoAccessTypes { get; set; }
    }
}