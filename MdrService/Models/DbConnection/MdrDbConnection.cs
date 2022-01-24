using MdrService.Configs;
using MdrService.Models.Links;
using MdrService.Models.Object;
using MdrService.Models.Study;
using Microsoft.EntityFrameworkCore;

namespace MdrService.Models.DbConnection
{
    public class MdrDbConnection : DbContext
    {
        public MdrDbConnection(DbContextOptions<MdrDbConnection> options) 
            : base(options)
        {
            
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(DbConfig.MdrDbConnectionString);

        
        // Study tables
        public DbSet<Study.Study> Studies { get; set; }
        public DbSet<StudyContributor> StudyContributors { get; set; }
        public DbSet<StudyFeature> StudyFeatures { get; set; }
        public DbSet<StudyIdentifier> StudyIdentifiers { get; set; }
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
        
        // Links
        public DbSet<StudyObjectLink> StudyObjectLinks { get; set; }
        
    }
}