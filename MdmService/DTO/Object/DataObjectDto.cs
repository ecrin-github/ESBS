using System;
using System.Collections.Generic;
using HotChocolate.Data;

#nullable enable
namespace MdmService.DTO.Object
{
    public class DataObjectDto
    {
        public int? Id { get; set; }
        
        public string? SdOid { get; set; }
        
        public string? SdSid { get; set; }
        
        public string? DisplayTitle { get; set; }
        
        public string? Version { get; set; }
        
        public string? Doi { get; set; }
        
        public int? DoiStatusId { get; set; }
        
        public int? PublicationYear { get; set; }
        
        public int? ObjectClassId { get; set; }
        
        public int? ObjectTypeId { get; set; }
        
        public int? ManagingOrgId { get; set; }
        
        public string? ManagingOrg { get; set; }
        
        public string? ManagingOrgRorId { get; set; }
        
        public string? LangCode { get; set; }
        
        public int? AccessTypeId { get; set; }
        
        public string? AccessDetails { get; set; }
        
        public string? AccessDetailsUrl { get; set; }
        
        public DateTime? UrlLastChecked { get; set; } 
        
        public int? EoscCategory { get; set; }
        
        public bool? AddStudyContribs { get; set; }
        
        public bool? AddStudyTopics { get; set; }
        
        public DateTime? CreatedOn { get; set; }
        
        [UseFiltering]
        [UseSorting]
        public ICollection<ObjectContributorDto>? ObjectContributors { get; set; }
        
        [UseFiltering]
        [UseSorting]
        public ICollection<ObjectDatasetDto>? ObjectDatasets { get; set; }
        
        [UseFiltering]
        [UseSorting]
        public ICollection<ObjectDateDto>? ObjectDates { get; set; }
        
        [UseFiltering]
        [UseSorting]
        public ICollection<ObjectDescriptionDto>? ObjectDescriptions { get; set; }
        
        [UseFiltering]
        [UseSorting]
        public ICollection<ObjectIdentifierDto>? ObjectIdentifiers { get; set; }
        
        [UseFiltering]
        [UseSorting]
        public ICollection<ObjectInstanceDto>? ObjectInstances { get; set; }
        
        [UseFiltering]
        [UseSorting]
        public ICollection<ObjectRelationshipDto>? ObjectRelationships { get; set; }
        
        [UseFiltering]
        [UseSorting]
        public ICollection<ObjectRightDto>? ObjectRights { get; set; }
        
        [UseFiltering]
        [UseSorting]
        public ICollection<ObjectTitleDto>? ObjectTitles { get; set; }
        
        [UseFiltering]
        [UseSorting]
        public ICollection<ObjectTopicDto>? ObjectTopics { get; set; }
    }
}