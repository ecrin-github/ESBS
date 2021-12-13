using System.Collections.Generic;

namespace MdrService.Contracts.Responses.v1.ApiResponse.StudyListResponse
{
    #nullable enable
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
        public IEnumerable<StudyIdentifierListResponse>? StudyIdentifiers { get; set; }
        public IEnumerable<StudyTitleListResponse>? StudyTitles { get; set; }
        public IEnumerable<StudyFeatureListResponse>? StudyFeatures { get; set; }
        public IEnumerable<StudyTopicListResponse>? StudyTopics { get; set; }
        public IEnumerable<StudyRelationListResponse>? StudyRelationships { get; set; }
        public string? ProvenanceString { get; set; }
        public IEnumerable<ObjectListResponse.ObjectListResponse>? LinkedDataObjects { get; set; }
    }
}