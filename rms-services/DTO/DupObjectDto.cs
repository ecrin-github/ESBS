using System;

#nullable enable
namespace rms_services.DTO
{
    public class DupObjectDto
    {
        public int Id { get; set; }
        
        public int DupId { get; set; }
        
        public string? ObjectId { get; set; }
        
        public int? AccessTypeId { get; set; }
        
        public string? AccessDetails { get; set; }
        
        public string? Notes { get; set; }
        
        public DateTime? CreatedOn { get; set; }
    }
}