using System;
using LinqToDB;
using LinqToDB.Mapping;

#nullable enable
namespace rms_services.Models
{
    [Table("dtps", Schema = "rms")]
    public class Dtp
    {
        [PrimaryKey, Identity]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("org_id")]
        public int? OrgId { get; set; }
        
        [Column("display_name")]
        public string? DisplayName { get; set; }
        
        [Column("status_id")]
        public int? StatusId { get; set; }
        
        [Column("initial_contact_date", DataType = DataType.Date)]
        public DateTime? InitialContactDate { get; set; }
        
        [Column("set_up_completed", DataType = DataType.Date)]
        public DateTime? SetUpCompleted { get; set; }
        
        [Column("md_access_granted", DataType = DataType.Date)]
        public DateTime? MdAccessGranted { get; set; }
        
        [Column("md_complete_date", DataType = DataType.Date)]
        public DateTime? MdCompleteDate { get; set; }

        [Column("dta_agreed_date", DataType = DataType.Date)]
        public DateTime? DtaAgreedDate { get; set; }
        
        [Column("upload_access_requested", DataType = DataType.Date)]
        public DateTime? UploadAccessRequested { get; set; }
        
        [Column("upload_access_confirmed", DataType = DataType.Date)]
        public DateTime? UploadAccessConfirmed { get; set; }
        
        [Column("uploads_complete", DataType = DataType.Date)]
        public DateTime? UploadsComplete { get; set; }
        
        [Column("qc_checks_completed", DataType = DataType.Date)]
        public DateTime? QcChecksCompleted { get; set; }
        
        [Column("md_integrated_with_mdr", DataType = DataType.Date)]
        public DateTime? MdIntegratedWithMdr { get; set; }
        
        [Column("availability_requested", DataType = DataType.Date)]
        public DateTime? AvailabilityRequested { get; set; }
        
        [Column("availability_confirmed", DataType = DataType.Date)]
        public DateTime? AvailabilityConfirmed { get; set; }
        
        [Column("created_on", DataType = DataType.Date)]
        public DateTime? CreatedOn { get; set; }
    }
}