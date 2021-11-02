using System;

#nullable enable
namespace MdmService.DTO.Object
{
    public class ObjectDescriptionDto
    {
        public int? Id { get; set; }
        
        public string? SdOid { get; set; }
        
        public int? DescriptionTypeId { get; set; }
        
        public string? Label { get; set; }
        
        public string? DescriptionText { get; set; }
        
        public string? LangCode { get; set; }
        
        public DateTime? CreatedOn { get; set; }
    }
}