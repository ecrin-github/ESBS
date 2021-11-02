using System;

#nullable enable
namespace RmsService.DTO
{
    public class DtpDatasetDto
    {
        public int Id { get; set; }
        
        public string? ObjectId { get; set; }
        
        public int? LegalStatusId { get; set; }
        
        public string? LegalStatusText { get; set; }
        
        public string? LegalStatusPath { get; set; }
        
        public int? DescmdCheckStatusId { get; set; }
        
        public DateTime? DescmdCheckDate { get; set; }
        
        public int? DescmdCheckBy { get; set; }
        
        public int? DeidentCheckStatusId { get; set; }
        
        public DateTime? DeidentCheckDate { get; set; }
        
        public int? DeidentCheckBy { get; set; }
        
        public string? Notes { get; set; }
        
        public DateTime? CreatedOn { get; set; }
    }
}