using System;
using LinqToDB;
using LinqToDB.Mapping;

#nullable enable
namespace rms_services.Models
{
    [Table("dtp_objects", Schema = "rms")]
    public class DtpObject
    {
        [PrimaryKey, Identity]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("dtp_id")]
        public int DtpId { get; set; }
        
        [Column("object_id")]
        public string? ObjectId { get; set; }
        
        [Column("is_dataset")]
        public bool? IsDataset { get; set; }
        
        [Column("access_type_id")]
        public int? AccessTypeId { get; set; }
        
        [Column("download_allowed")]
        public bool? DownloadAllowed { get; set; }
        
        [Column("access_details")]
        public string? AccessDetails { get; set; }
        
        [Column("requires_embargo_period")]
        public bool? RequiresEmbargoPeriod { get; set; }
        
        [Column("embargo_end_date", DataType = DataType.Date)]
        public DateTime? EmbargoEndDate { get; set; }
        
        [Column("embargo_still_applies")]
        public bool? EmbargoStillApplies { get; set; }
        
        [Column("access_check_status_id")]
        public int? AccessCheckStatusId { get; set; }
        
        [Column("access_check_date", DataType = DataType.Date)]
        public DateTime? AccessCheckDate { get; set; }
        
        [Column("access_check_by")]
        public string? AccessCheckBy { get; set; }
        
        [Column("md_check_status_id")]
        public int? MdCheckStatusId { get; set; }
        
        [Column("md_check_date", DataType = DataType.Date)]
        public DateTime? MdCheckDate { get; set; }
        
        [Column("md_check_by")]
        public string? MdCheckBy { get; set; }
        
        [Column("notes")]
        public string? Notes { get; set; }
        
        [Column("created_on")]
        public DateTime? CreatedOn { get; set; }
    }
}