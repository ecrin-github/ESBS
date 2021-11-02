using System;

#nullable enable
namespace MdmService.DTO.Object
{
    public class ObjectRightDto
    {
        public int? Id { get; set; }
        
        public string? SdOid { get; set; }
        
        public string? RightsName { get; set; }
        
        public string? RightsUri { get; set; }
        
        public string? Comments { get; set; }
        
        public DateTime? CreatedOn { get; set; }
    }
}