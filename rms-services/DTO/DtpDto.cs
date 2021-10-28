using System;

#nullable enable
namespace rms_services.DTO
{
    public class DtpDto
    {
        public int Id { get; set; }
        
        public int? OrgId { get; set; }
        
        public string? DisplayName { get; set; }
        
        public int? StatusId { get; set; }
        
        public DateTime? InitialContactDate { get; set; }
        
        public DateTime? SetUpCompleted { get; set; }
        
        public DateTime? MdAccessGranted { get; set; }
        
        public DateTime? MdCompleteDate { get; set; }

        public DateTime? DtaAgreedDate { get; set; }
        
        public DateTime? UploadAccessRequested { get; set; }
        
        public DateTime? UploadAccessConfirmed { get; set; }
        
        public DateTime? UploadsComplete { get; set; }
        
        public DateTime? QcChecksCompleted { get; set; }
        
        public DateTime? MdIntegratedWithMdr { get; set; }
        
        public DateTime? AvailabilityRequested { get; set; }
        
        public DateTime? AvailabilityConfirmed { get; set; }
        
        public DateTime? CreatedOn { get; set; }
    }
}