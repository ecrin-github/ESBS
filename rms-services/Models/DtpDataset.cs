using System;
using LinqToDB;
using LinqToDB.Mapping;

#nullable enable
namespace rms_services.Models
{
    [Table("dtp_datasets", Schema = "rms")]
    public class DtpDataset
    {
        [PrimaryKey, Identity]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("object_id")]
        public string? ObjectId { get; set; }
        
        [Column("legal_status_id")]
        public int? LegalStatusId { get; set; }
        
        [Column("legal_status_text")]
        public string? LegalStatusText { get; set; }
        
        [Column("legal_status_path")]
        public string? LegalStatusPath { get; set; }
        
        [Column("descmd_check_status_id")]
        public int? DescmdCheckStatusId { get; set; }
        
        [Column("descmd_check_date", DataType = DataType.Date)]
        public DateTime? DescmdCheckDate { get; set; }
        
        [Column("descmd_check_by")]
        public int? DescmdCheckBy { get; set; }
        
        [Column("deident_check_status_id")]
        public int? DeidentCheckStatusId { get; set; }
        
        [Column("deident_check_date", DataType = DataType.Date)]
        public DateTime? DeidentCheckDate { get; set; }
        
        [Column("deident_check_by")]
        public int? DeidentCheckBy { get; set; }
        
        [Column("notes")]
        public string? Notes { get; set; }
        
        [Column("created_on")]
        public DateTime? CreatedOn { get; set; }
    }
}