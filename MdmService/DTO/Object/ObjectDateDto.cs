using System;

#nullable enable
namespace MdmService.DTO.Object
{
    public class ObjectDateDto
    {
        public int? Id { get; set; }
        
        public string? SdOid { get; set; }
        
        public int? DateTypeId { get; set; }
        
        public bool? DateIsRange { get; set; }
        
        public string? DateAsString { get; set; }
        
        public int? StartYear { get; set; }
        
        public int? StartMonth { get; set; }
        
        public int? StartDay { get; set; }
        
        public int? EndYear { get; set; }
        
        public int? EndMonth { get; set; }
        
        public int? EndDay { get; set; }
        
        public string? Details { get; set; }
        
        public DateTime? CreatedOn { get; set; }
    }
}