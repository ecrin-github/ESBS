using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace RmsService.Models
{
    [Table("dtp_studies", Schema = "rms")]
    public class DtpStudy
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("dtp_id")]
        public int DtpId { get; set; }
        
        [Column("study_id")]
        public string? StudyId { get; set; }
        
        [Column("md_check_status_id")]
        public int? MdCheckStatusId { get; set; }
        
        [Column("md_check_date", TypeName = "Date")]
        public DateTime? MdCheckDate { get; set; }
        
        [Column("md_check_by")]
        public int? MdCheckBy { get; set; }
        
        [Column("created_on")]
        public DateTime? CreatedOn { get; set; }
    }
}