using System.Collections.Generic;
using HotChocolate.Data;

#nullable enable
namespace mdm_services.DTO.Study
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
        
        [UseFiltering]
        [UseSorting]
        public ICollection<StudyContributorDto>? StudyContributors { get; set; }
        
        [UseFiltering]
        [UseSorting]
        public ICollection<StudyFeatureDto>? StudyFeatures { get; set; }
        
        [UseFiltering]
        [UseSorting]
        public ICollection<StudyIdentifierDto>? StudyIdentifiers { get; set; }
        
        [UseFiltering]
        [UseSorting]
        public ICollection<StudyReferenceDto>? StudyReferences { get; set; }
        
        [UseFiltering]
        [UseSorting]
        public ICollection<StudyRelationshipDto>? StudyRelationships { get; set; }
        
        [UseFiltering]
        [UseSorting]
        public ICollection<StudyTitleDto>? StudyTitles { get; set; }
        
        [UseFiltering]
        [UseSorting]
        public ICollection<StudyTopicDto>? StudyTopics { get; set; }
    }
}