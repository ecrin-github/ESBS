using System;

#nullable enable
namespace mdm_services.DTO.Study
{
    public class StudyTopicDto
    {
        public int? Id { get; set; }
        
        public string? SdSid { get; set; }
        
        public int? TopicTypeId { get; set; }
        
        public bool? MeshCoded { get; set; }
        
        public string? MeshCode { get; set; }
        
        public string? MeshValue { get; set; }
        
        public string? MeshQualcode { get; set; }
        
        public string? MeshQualvalue { get; set; }
        
        public int? OriginalCtId { get; set; }
        
        public string? OriginalCtCode { get; set; }
        
        public string? OriginalValue { get; set; }
        
        public string? Comments { get; set; }
        
        public DateTime? CreatedOn { get; set; }
    }
}