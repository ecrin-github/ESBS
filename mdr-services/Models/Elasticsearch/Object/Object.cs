using System.Collections.Generic;
using Nest;

namespace mdr_services.Models.Elasticsearch.Object
{
    public class Object
    {
        [Number(Name = "id")]
        #nullable enable
        public int? Id { get; set; }
        
        [Text(Name = "file_type")]
        #nullable enable
        public string? FileType { get; set; }
        
        [Text(Name = "doi")]
        #nullable enable
        public string? Doi { get; set; }
        
        [Text(Name = "display_title")]
        #nullable enable
        public string? DisplayTitle { get; set; }
        
        [Text(Name = "version")]
        #nullable enable
        public string? Version { get; set; }
        
        [Object]
        [PropertyName("object_class")]
        #nullable enable
        public ObjectClass? ObjectClass { get; set; }
        
        [Object]
        [PropertyName("object_type")]
        #nullable enable
        public ObjectType? ObjectType { get; set; }
        
        [Date(Name = "publication_year", Format = "YYYY")]
        #nullable enable
        public int? PublicationYear { get; set; }
        
        [Text(Name = "lang_code")]
        #nullable enable
        public string? LangCode { get; set; }
        
        [Object]
        [PropertyName("managing_organisation")]
        #nullable enable
        public ManagingOrg? ManagingOrganisation { get; set; }
        
        [Object]
        [PropertyName("access_type")]
        #nullable enable
        public AccessType? AccessType { get; set; }
        
        [Object]
        [PropertyName("access_details")]
        #nullable enable
        public AccessDetails? AccessDetails { get; set; }
        
        [Number(Name = "eosc_category")]
        #nullable enable
        public int? EoscCategory { get; set; } 
        
        [Object]
        [PropertyName("dataset_record_keys")]
        #nullable enable
        public DatasetRecordKeys? DatasetRecordKeys { get; set; }
        
        [Object]
        [PropertyName("dataset_deident_level")]
        #nullable enable
        public DatasetDeidentLevel? DatasetDeidentLevel { get; set; }
        
        [Object]
        [PropertyName("dataset_consent")]
        #nullable enable
        public DatasetConsent? DatasetConsent { get; set; }
        
        [Nested]
        [PropertyName("object_instances")]
        #nullable enable
        public ICollection<ObjectInstance>? ObjectInstances { get; set; }
        
        [Nested]
        [PropertyName("object_titles")]
        #nullable enable
        public ICollection<ObjectTitle>? ObjectTitles { get; set; }
        
        [Nested]
        [PropertyName("object_dates")]
        #nullable enable
        public ICollection<ObjectDate>? ObjectDates { get; set; }
        
        [Nested]
        [PropertyName("object_contributors")]
        #nullable enable
        public ICollection<ObjectContributor>? ObjectContributors { get; set; }
        
        [Nested]
        [PropertyName("object_topics")]
        #nullable enable
        public ICollection<ObjectTopic>? ObjectTopics { get; set; }
        
        [Nested]
        [PropertyName("object_identifiers")]
        #nullable enable
        public ICollection<ObjectIdentifier>? ObjectIdentifiers { get; set; }
        
        [Nested]
        [PropertyName("object_descriptions")]
        #nullable enable
        public ICollection<ObjectDescription>? ObjectDescriptions { get; set; }
        
        [Nested]
        [PropertyName("object_rights")]
        #nullable enable
        public ICollection<ObjectRight>? ObjectRights { get; set; }
        
        [Nested]
        [PropertyName("object_relationships")]
        #nullable enable
        public ICollection<ObjectRelationship>? ObjectRelationships { get; set; }
        
        [Number(Name = "linked_studies")]
        #nullable enable
        public int[]? LinkedStudies { get; set; }
        
        [Text(Name = "provenance_string")]
        #nullable enable
        public string? ProvenanceString { get; set; }
    }
}