using System;

#nullable enable
namespace RmsService.DTO
{
    public class DtpObjectDto
    {
        public int Id { get; set; }
        
        public int DtpId { get; set; }
        
        public string? ObjectId { get; set; }
        
        public bool? IsDataset { get; set; }
        
        public int? AccessTypeId { get; set; }
        
        public bool? DownloadAllowed { get; set; }
        
        public string? AccessDetails { get; set; }
        
        public bool? RequiresEmbargoPeriod { get; set; }
        
        public DateTime? EmbargoEndDate { get; set; }
        
        public bool? EmbargoStillApplies { get; set; }
        
        public int? AccessCheckStatusId { get; set; }
        
        public DateTime? AccessCheckDate { get; set; }
        
        public string? AccessCheckBy { get; set; }
        
        public int? MdCheckStatusId { get; set; }
        
        public DateTime? MdCheckDate { get; set; }
        
        public string? MdCheckBy { get; set; }
        
        public string? Notes { get; set; }
        
        public DateTime? CreatedOn { get; set; }
    }
}