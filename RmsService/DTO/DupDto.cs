using System;

#nullable enable
namespace RmsService.DTO
{
    public class DupDto
    {
        public int Id { get; set; }
        
        public int OrgId { get; set; }
        
        public string? DisplayName { get; set; }
        
        public int? StatusId { get; set; }
        
        public DateTime? InitialContactDate { get; set; }
        
        public DateTime? SetUpCompleted { get; set; }
        
        public DateTime? PrereqsMet { get; set; }
        
        public DateTime? DuaAgreedDate { get; set; }
        
        public DateTime? AvailabilityRequested { get; set; }
        
        public DateTime? AvailabilityConfirmed { get; set; }
        
        public DateTime? AccessConfirmed { get; set; }
        
        public DateTime? CreatedOn { get; set; }
    }
}