using System.Collections.Generic;
using Nest;

namespace MdrService.Models.Elasticsearch.Study
{
    public class Study
    {
        [Number(Name = "id")]
        #nullable enable
        public int? Id { get; set; }
        
        [Text(Name = "file_type")]
        #nullable enable
        public string? FileType { get; set; }
        
        [Text(Name = "display_title")]
        #nullable enable
        public string? DisplayTitle { get; set; }
        
        [Text(Name = "brief_description")]
        #nullable enable
        public string? BriefDescription { get; set; }
        
        [Text(Name = "data_sharing_statement")]
        #nullable enable
        public string? DataSharingStatement { get; set; }
        
        [Object]
        [PropertyName("study_type")]
        #nullable enable
        public StudyType? StudyType { get; set; }
        
        [Object]
        [PropertyName("study_status")]
        #nullable enable
        public StudyStatus? StudyStatus { get; set; }
        
        [Object]
        [PropertyName("study_gender_elig")]
        #nullable enable
        public StudyGenderElig? StudyGenderElig { get; set; }
        
        [Text(Name = "study_enrolment")]
        #nullable enable
        public string? StudyEnrolment { get; set; }
        
        [Object]
        [PropertyName("min_age")]
        #nullable enable
        public MinAge? MinAge { get; set; }
        
        [Object]
        [PropertyName("max_age")]
        #nullable enable
        public MaxAge? MaxAge { get; set; }
        
        [Nested]
        [PropertyName("study_identifiers")]
        #nullable enable
        public ICollection<StudyIdentifier>? StudyIdentifiers { get; set; }
        
        [Nested]
        [PropertyName("study_titles")]
        #nullable enable
        public ICollection<StudyTitle>? StudyTitles { get; set; }
        
        [Nested]
        [PropertyName("study_features")]
        #nullable enable
        public ICollection<StudyFeature>? StudyFeatures { get; set; }
        
        [Nested]
        [PropertyName("study_topics")]
        #nullable enable
        public ICollection<StudyTopic>? StudyTopics { get; set; }
        
        [Nested]
        [PropertyName("study_relationships")]
        #nullable enable
        public ICollection<StudyRelation>? StudyRelationships { get; set; }
        
        [Text(Name="provenance_string")]
        #nullable enable
        public string? ProvenanceString { get; set; }
        
        [Nested]
        [PropertyName("linked_data_objects")]
        #nullable enable
        public ICollection<Object.Object>? LinkedDataObjects { get; set; }
    }
}