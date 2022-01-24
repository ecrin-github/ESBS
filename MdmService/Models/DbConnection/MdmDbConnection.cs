using MdmService.Configs;
using MdmService.Models.Audit;
using MdmService.Models.Object;
using MdmService.Models.Study;
using Microsoft.EntityFrameworkCore;

namespace MdmService.Models.DbConnection
{
    public class MdmDbConnection : DbContext
    {
        public MdmDbConnection(DbContextOptions<MdmDbConnection> options) 
            : base(options)
        {
            
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql($"Host={DbConfigs.RmsDbConfigs.Host};Database={DbConfigs.RmsDbConfigs.Database};Username={DbConfigs.RmsDbConfigs.Username};Password={DbConfigs.RmsDbConfigs.Password}");

        
        // Study tables
        public DbSet<Study.Study> Studies { get; set; }
        public DbSet<StudyContributor> StudyContributors { get; set; }
        public DbSet<StudyFeature> StudyFeatures { get; set; }
        public DbSet<StudyIdentifier> StudyIdentifiers { get; set; }
        public DbSet<StudyReference> StudyReferences { get; set; }
        public DbSet<StudyRelationship> StudyRelationships { get; set; }
        public DbSet<StudyTitle> StudyTitles { get; set; }
        public DbSet<StudyTopic> StudyTopics { get; set; }
        
        // Data object tables
        public DbSet<DataObject> DataObjects { get; set; }
        public DbSet<ObjectContributor> ObjectContributors { get; set; }
        public DbSet<ObjectDataset> ObjectDatasets { get; set; }
        public DbSet<ObjectDate> ObjectDates { get; set; }
        public DbSet<ObjectDescription> ObjectDescriptions { get; set; }
        public DbSet<ObjectIdentifier> ObjectIdentifiers { get; set; }
        public DbSet<ObjectInstance> ObjectInstances { get; set; }
        public DbSet<ObjectRelationship> ObjectRelationships { get; set; }
        public DbSet<ObjectRight> ObjectRights { get; set; }
        public DbSet<ObjectTitle> ObjectTitles { get; set; }
        public DbSet<ObjectTopic> ObjectTopics { get; set; }


        // Audit
        public DbSet<RecordChange> RecordChanges {get; set;}
    }
}