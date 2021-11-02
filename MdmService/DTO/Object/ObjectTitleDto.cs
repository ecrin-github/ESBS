using System;

#nullable enable
namespace MdmService.DTO.Object
{
    public class ObjectTitleDto
    {
        public int? Id { get; set; }
        
        public string? SdOid { get; set; }
        
        public int? TitleTypeId { get; set; }
        
        public string? TitleText { get; set; }
        
        public string? LangCode { get; set; }
        
        public int? LangUsageId { get; set; }
        
        public bool? IsDefault { get; set; }
        
        public string? Comments { get; set; }
        
        public DateTime? CreatedOn { get; set; }
    }
}