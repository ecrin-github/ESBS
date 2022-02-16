using System;

#nullable enable
namespace MdmService.DTO.Study
{
    public class StudyTopicDto
    {
        public int? Id { get; set; }
        
        public string? SdSid { get; set; }
        
        public int? TopicTypeId { get; set; }
        
        public bool? MeshCoded { get; set; }
        
        public string? MeshCode { get; set; }
        
        public string? MeshValue { get; set; }

        public int? OriginalCtId { get; set; }
        
        public string? OriginalCtCode { get; set; }
        
        public string? OriginalValue { get; set; }
        
        public DateTime? CreatedOn { get; set; }
    }
}