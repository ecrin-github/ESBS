using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace RmsService.Models
{
    [Table("dtps", Schema = "rms")]
    public class Dtp
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("org_id")]
        public int? OrgId { get; set; }
        
        [Column("display_name")]
        public string? DisplayName { get; set; }
        
        [Column("status_id")]
        public int? StatusId { get; set; }
        
        [Column("initial_contact_date", TypeName = "Date")]
        public DateTime? InitialContactDate { get; set; }
        
        [Column("set_up_completed", TypeName = "Date")]
        public DateTime? SetUpCompleted { get; set; }
        
        [Column("md_access_granted", TypeName = "Date")]
        public DateTime? MdAccessGranted { get; set; }
        
        [Column("md_complete_date", TypeName = "Date")]
        public DateTime? MdCompleteDate { get; set; }

        [Column("dta_agreed_date", TypeName = "Date")]
        public DateTime? DtaAgreedDate { get; set; }
        
        [Column("upload_access_requested", TypeName = "Date")]
        public DateTime? UploadAccessRequested { get; set; }
        
        [Column("upload_access_confirmed", TypeName = "Date")]
        public DateTime? UploadAccessConfirmed { get; set; }
        
        [Column("uploads_complete", TypeName = "Date")]
        public DateTime? UploadsComplete { get; set; }
        
        [Column("qc_checks_completed", TypeName = "Date")]
        public DateTime? QcChecksCompleted { get; set; }
        
        [Column("md_integrated_with_mdr", TypeName = "Date")]
        public DateTime? MdIntegratedWithMdr { get; set; }
        
        [Column("availability_requested", TypeName = "Date")]
        public DateTime? AvailabilityRequested { get; set; }
        
        [Column("availability_confirmed", TypeName = "Date")]
        public DateTime? AvailabilityConfirmed { get; set; }
        
        [Column("created_on", TypeName = "Date")]
        public DateTime? CreatedOn { get; set; }
    }
}