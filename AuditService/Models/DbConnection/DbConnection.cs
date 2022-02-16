using AuditService.Configs;
using AuditService.Models.Audit.MDR;
using AuditService.Models.Audit.RMS;
using Microsoft.EntityFrameworkCore;

namespace AuditService.Models.DbConnection
{
    public class DbConnection : DbContext
    {
        public DbConnection(DbContextOptions<DbConnection> options) 
            : base(options)
        {
            
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql($"Host={DbConfigs.AuditDbConfig.Host};Database={DbConfigs.AuditDbConfig.Database};Username={DbConfigs.AuditDbConfig.Username};Password={DbConfigs.AuditDbConfig.Password}");


        // Audit
        public DbSet<MdrRecordChange> MdrRecordChanges {get; set;}
        public DbSet<RmsRecordChange> RmsRecordChanges {get; set;}
    }
}