using Microsoft.EntityFrameworkCore;
using RmsService.Configs;

namespace RmsService.Models.DbConnection
{
    public class RmsDbConnection : DbContext
    {
        public RmsDbConnection(DbContextOptions<RmsDbConnection> options) 
            : base(options)
        {
            
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(DbConfigs.DbConnectionString);


        public DbSet<AccessPrereq> AccessPrereqs { get; set; }
        public DbSet<Dta> Dtas { get; set; }
        public DbSet<Dtp> Dtps { get; set; }
        public DbSet<DtpDataset> DtpDatasets { get; set; }
        public DbSet<DtpObject> DtpObjects { get; set; }
        public DbSet<DtpStudy> DtpStudies { get; set; }
        public DbSet<Dua> Duas { get; set; }
        public DbSet<Dup> Dups { get; set; }
        public DbSet<DupObject> DupObjects { get; set; }
        public DbSet<DupPrereq> DupPrereqs { get; set; }
        public DbSet<ProcessNote> ProcessNotes { get; set; }
        public DbSet<ProcessPeople> ProcessPeople { get; set; }
        public DbSet<SecondaryUse> SecondaryUses { get; set; }
    }
}