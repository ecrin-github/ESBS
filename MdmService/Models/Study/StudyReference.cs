using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace MdmService.Models.Study
{
    [Table("study_references", Schema = "mdr")]
    public class StudyReference
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("sd_sid")]
        public string? SdSid { get; set; }
        
        [Column("pmid")]
        public string? Pmid { get; set; }
        
        [Column("citation")]
        public string? Citation { get; set; }
        
        [Column("doi")]
        public string? Doi { get; set; }
        
        [Column("comments")]
        public string? Comments { get; set; }
        
        [Column("created_on")]
        public DateTime? CreatedOn { get; set; }
    }
}