using System.Collections.Generic;
using MdrService.Models.Elasticsearch.Object;
using Nest;

#nullable enable
namespace MdrService.Models.Elasticsearch.Study
{
    [ElasticsearchType(RelationName = "study")]
    public class Study
    {
        [Number(Name = "id")]
        public int? Id { get; set; }

        [Text(Name = "display_title")]
        public string? DisplayTitle { get; set; }
        
        [Text(Name = "brief_description")]
        public string? BriefDescription { get; set; }
        
        [Text(Name = "data_sharing_statement")]
        public string? DataSharingStatement { get; set; }
        
        [Object]
        [PropertyName("study_type")]
        public StudyType? StudyType { get; set; }
        
        [Object]
        [PropertyName("study_status")]
        public StudyStatus? StudyStatus { get; set; }
        
        [Object]
        [PropertyName("study_gender_elig")]
        public StudyGenderElig? StudyGenderElig { get; set; }
        
        [Text(Name = "study_enrolment")]
        public string? StudyEnrolment { get; set; }
        
        [Object]
        [PropertyName("min_age")]
        public MinAge? MinAge { get; set; }
        
        [Object]
        [PropertyName("max_age")]
        public MaxAge? MaxAge { get; set; }
        
        [Nested]
        [PropertyName("study_identifiers")]
        public ICollection<StudyIdentifier>? StudyIdentifiers { get; set; }
        
        [Nested]
        [PropertyName("study_titles")]
        public ICollection<StudyTitle>? StudyTitles { get; set; }
        
        [Nested]
        [PropertyName("study_features")]
        public ICollection<StudyFeature>? StudyFeatures { get; set; }
        
        [Nested]
        [PropertyName("study_topics")]
        public ICollection<StudyTopic>? StudyTopics { get; set; }
        
        [Nested]
        [PropertyName("study_relationships")]
        public ICollection<StudyRelation>? StudyRelationships { get; set; }
        
        [Text(Name="provenance_string")]
        public string? ProvenanceString { get; set; }
        
        [Nested]
        [PropertyName("linked_data_objects")]
        public ICollection<DataObject>? LinkedDataObjects { get; set; }
    }
}