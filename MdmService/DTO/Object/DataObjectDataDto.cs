using System;

#nullable enable
namespace MdmService.DTO.Object
{
    public class DataObjectDataDto
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
    }
}