using System.Collections.Generic;

#nullable enable
namespace mdr_services.Contracts.Responses.v1.StudyListResponse
{
    public class StudyListResponse
    {
        public int? Id { get; set; }
        public string? DisplayTitle { get; set; }
        public string? BriefDescription { get; set; }
        public string? StudyType { get; set; }
        public string? StudyStatus { get; set; }
        public string? StudyGenderElig { get; set; }
        public string? StudyEnrolment { get; set; }
        public MinAgeResponse? MinAge { get; set; }
        public MaxAgeResponse? MaxAge { get; set; }
        public ICollection<StudyIdentifierListResponse>? StudyIdentifiers { get; set; }
        public ICollection<StudyTitleListResponse>? StudyTitles { get; set; }
        public ICollection<StudyFeatureListResponse>? StudyFeatures { get; set; }
        public ICollection<StudyTopicListResponse>? StudyTopics { get; set; }
        public ICollection<StudyRelationListResponse>? StudyRelationships { get; set; }
        public string? ProvenanceString { get; set; }
        public ICollection<ObjectListResponse.ObjectListResponse>? LinkedDataObjects { get; set; }
    }
}