using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Data;
using mdm_services.Models.Object;
using mdm_services.Models.Study;

namespace mdm_services.Models.DbConnection
{
    public class MdmDbConnection : DataConnection
    {
        public MdmDbConnection(LinqToDbConnectionOptions<MdmDbConnection> options) 
            : base(options)
        {
            
        }
        
        // Study tables
        public ITable<Study.Study> Studies => GetTable<Study.Study>();
        public ITable<StudyContributor> StudyContributors => GetTable<StudyContributor>();
        public ITable<StudyFeature> StudyFeatures => GetTable<StudyFeature>();
        public ITable<StudyIdentifier> StudyIdentifiers => GetTable<StudyIdentifier>();
        public ITable<StudyReference> StudyReferences => GetTable<StudyReference>();
        public ITable<StudyRelationship> StudyRelationships => GetTable<StudyRelationship>();
        public ITable<StudyTitle> StudyTitles => GetTable<StudyTitle>();
        public ITable<StudyTopic> StudyTopics => GetTable<StudyTopic>();
        
        // Data object tables
        public ITable<DataObject> DataObjects => GetTable<DataObject>();
        public ITable<ObjectContributor> ObjectContributors => GetTable<ObjectContributor>();
        public ITable<ObjectDataset> ObjectDatasets => GetTable<ObjectDataset>();
        public ITable<ObjectDate> ObjectDates => GetTable<ObjectDate>();
        public ITable<ObjectDescription> ObjectDescriptions => GetTable<ObjectDescription>();
        public ITable<ObjectIdentifier> ObjectIdentifiers => GetTable<ObjectIdentifier>();
        public ITable<ObjectInstance> ObjectInstances => GetTable<ObjectInstance>();
        public ITable<ObjectRelationship> ObjectRelationships => GetTable<ObjectRelationship>();
        public ITable<ObjectRight> ObjectRights => GetTable<ObjectRight>();
        public ITable<ObjectTitle> ObjectTitles => GetTable<ObjectTitle>();
        public ITable<ObjectTopic> ObjectTopics => GetTable<ObjectTopic>();
    }
}