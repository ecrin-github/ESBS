using System;

#nullable enable
namespace rms_services.DTO
{
    public class SecondaryUseDto
    {
        public int Id { get; set; }
        
        public int DupId { get; set; }
        
        public string? SecondaryUseType { get; set; }
        
        public string? Publication { get; set; }
        
        public string? Doi { get; set; }
        
        public bool? AttributionPresent { get; set; }
        
        public string? Notes { get; set; }
        
        public DateTime? CreatedOn { get; set; }
    }
}