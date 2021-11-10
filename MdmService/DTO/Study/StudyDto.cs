using System.Collections.Generic;

#nullable enable
namespace MdmService.DTO.Study
{
    public class StudyDto
    {
        public int? Id { get; set; }
        
        public string? SdSid { get; set; }
        
        public string? MdrSdSid { get; set; }
        
        public int? MdrSourceId { get; set; }
        
        public string? DisplayTitle { get; set; }
        
        public string? TitleLangCode { get; set; }
        
        public string? BriefDescription { get; set; }
        
        public string? DataSharingStatement { get; set; }
        
        public int? StudyStartYear { get; set; }
        
        public int? StudyStartMonth { get; set; }
        
        public int? StudyTypeId { get; set; }
        
        public int? StudyStatusId { get; set; }
        
        public int? StudyEnrolment { get; set; }
        
        public int? StudyGenderEligId { get; set; }
        
        public int? MinAge { get; set; }
        
        public int? MinAgeUnitsId { get; set; }
        
        public int? MaxAge { get; set; }
        
        public int? MaxAgeUnitsId { get; set; }
        
        public string? CreatedOn { get; set; }
        
        public ICollection<StudyContributorDto>? StudyContributors { get; set; }
        
        public ICollection<StudyFeatureDto>? StudyFeatures { get; set; }
        
        public ICollection<StudyIdentifierDto>? StudyIdentifiers { get; set; }
        
        public ICollection<StudyReferenceDto>? StudyReferences { get; set; }
        
        public ICollection<StudyRelationshipDto>? StudyRelationships { get; set; }
        
        public ICollection<StudyTitleDto>? StudyTitles { get; set; }
        
        public ICollection<StudyTopicDto>? StudyTopics { get; set; }
    }
}