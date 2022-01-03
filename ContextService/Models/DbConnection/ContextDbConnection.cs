using ContextService.Models.Ctx;
using ContextService.Models.Lup;
using ContextService.Configs;
using Microsoft.EntityFrameworkCore;

namespace ContextService.Models.DbConnection
{
    public class ContextDbConnection : DbContext
    {

        public ContextDbConnection(DbContextOptions<ContextDbConnection> options) 
            : base(options)
        {
            
        }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql($"Host={DbConfigs.ContextDbConfigs.Host};Database={DbConfigs.ContextDbConfigs.Database};Username={DbConfigs.ContextDbConfigs.Username};Password={DbConfigs.ContextDbConfigs.Password}");


        // Lup tables
        public DbSet<CompositeHashType> CompositeHashTypes { get; set; }
        public DbSet<ContributionType> ContributionTypes { get; set; }
        public DbSet<DatasetConsentType> DatasetConsentTypes { get; set; }
        public DbSet<DatasetDeidentificationLevel> DatasetDeidentificationLevels { get; set; }
        public DbSet<DatasetRecordkeyType> DatasetRecordkeyTypes { get; set; }
        public DbSet<DateType> DateTypes { get; set; }
        public DbSet<DescriptionType> DescriptionTypes { get; set; }
        public DbSet<DoiStatusType> DoiStatusTypes { get; set; }
        public DbSet<GenderEligibilityType> GenderEligibilityTypes { get; set; }
        public DbSet<GeogEntityType> GeogEntityTypes { get; set; }
        public DbSet<IdentifierType> IdentifierTypes { get; set; }
        public DbSet<LanguageCode> LanguageCodes { get; set; }
        public DbSet<LanguageUsageType> LanguageUsageTypes { get; set; }
        public DbSet<LinkType> LinkTypes { get; set; }
        public DbSet<ObjectAccessType> ObjectAccessTypes { get; set; }
        public DbSet<ObjectClass> ObjectClasses { get; set; }
        public DbSet<ObjectFilterType> ObjectFilterTypes { get; set; }
        public DbSet<ObjectInstanceType> ObjectInstanceTypes { get; set; }
        public DbSet<ObjectRelationshipType> ObjectRelationshipTypes { get; set; }
        public DbSet<ObjectType> ObjectTypes { get; set; }

        public DbSet<OrgAttributeDatatype> OrgAttributeDatatypes {get; set;}
        public DbSet<OrgAttributeType> OrgAttributeTypes {get; set;}
        public DbSet<OrgClass> OrgClasses {get; set;}
        public DbSet<OrgLinkType> OrgLinkTypes {get; set;}
        public DbSet<OrgNameQualifierType> OrgNameQualifierTypes {get; set;}
        public DbSet<OrgRelationshipType> OrgRelationshipTypes {get; set;}
        public DbSet<OrgType> OrgTypes {get; set;}
        public DbSet<ResourceType> ResourceTypes { get; set; }
        public DbSet<RmsUserType> RmsUserTypes { get; set; }
        public DbSet<RoleClass> RoleClasses { get; set; }
        public DbSet<RoleType> RoleTypes { get; set; }
        public DbSet<SizeUnit> SizeUnits { get; set; }
        public DbSet<StudyFeatureCategory> StudyFeatureCategories { get; set; }
        public DbSet<StudyFeatureType> StudyFeatureTypes { get; set; }
        public DbSet<StudyRelationshipType> StudyRelationshipTypes { get; set; }
        public DbSet<StudyStatus> StudyStatuses { get; set; }
        public DbSet<StudyType> StudyTypes { get; set; }
        public DbSet<TimeUnit> TimeUnits { get; set; }
        public DbSet<TitleType> TitleTypes { get; set; }
        public DbSet<TopicType> TopicTypes { get; set; }
        public DbSet<TopicVocabulary> TopicVocabularies {get; set;}

        
        // Ctx tables
        public DbSet<GeogEntity> GeogEntities {get; set;}
        public DbSet<MeshLookup> MeshLookups {get; set;}
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<OrgAttribute> OrgAttributes { get; set; }
        public DbSet<OrgLink> OrgLinks { get; set; }
        public DbSet<OrgLocation> OrgLocations { get; set; }
        public DbSet<OrgName> OrgNames { get; set; }
        public DbSet<OrgRelationship> OrgRelationships { get; set; }
        public DbSet<OrgTypeMembership> OrgTypeMemberships {get; set;}
        public DbSet<People> People { get; set; }
        public DbSet<PeopleLink> PeopleLinks { get; set; }
        public DbSet<PeopleRole> PeopleRoles { get; set; }
        public DbSet<PublishedJournal> PublishedJournals { get; set; }
        public DbSet<ToMatchOrg> ToMatchOrgs {get; set;}
        public DbSet<ToMatchTopic> ToMatchTopics {get; set;}
    }
}