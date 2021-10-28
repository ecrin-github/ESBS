using System;
using LinqToDB;
using LinqToDB.Mapping;

#nullable enable
namespace rms_services.Models
{
    [Table("dtp_studies", Schema = "rms")]
    public class DtpStudy
    {
        [PrimaryKey, Identity]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("dtp_id")]
        public int DtpId { get; set; }
        
        [Column("study_id")]
        public string? StudyId { get; set; }
        
        [Column("md_check_status_id")]
        public int? MdCheckStatusId { get; set; }
        
        [Column("md_check_date", DataType = DataType.Date)]
        public DateTime? MdCheckDate { get; set; }
        
        [Column("md_check_by")]
        public int? MdCheckBy { get; set; }
        
        [Column("created_on")]
        public DateTime? CreatedOn { get; set; }
    }
}