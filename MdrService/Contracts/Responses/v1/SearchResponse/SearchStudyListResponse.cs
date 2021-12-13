using System.Collections.Generic;

#nullable enable
namespace MdrService.Contracts.Responses.v1.SearchResponse
{
    public class SearchStudyListResponse
    {
        public int? Id { get; set; }
        public string? DisplayTitle { get; set; }
        public string? BriefDescription { get; set; }
        public string? StudyType { get; set; }
        public string? StudyStatus { get; set; }
        public string? StudyGenderElig { get; set; }
        public string? StudyEnrolment { get; set; }
        public string? ProvenanceString { get; set; }
        public IEnumerable<SearchDataObjectListResponse>? LinkedDataObjects { get; set; }
    }
}