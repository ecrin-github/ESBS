using System;

#nullable enable
namespace RmsService.DTO
{
    public class DtaDto
    {
        public int Id { get; set; }
        
        public int? DtpId { get; set; }
        
        public int? ConformsToDefault { get; set; }
        
        public string? Variations { get; set; }
        
        public int? RepoSignatory1 { get; set; }
        
        public int? RepoSignatory2 { get; set; }
        
        public int? ProviderSignatory1 { get; set; }
        
        public int? ProviderSignatory2 { get; set; }
        
        public string? Notes { get; set; }
        
        public DateTime? CreatedOn { get; set; }
    }
}