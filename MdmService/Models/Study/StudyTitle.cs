using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace MdmService.Models.Study
{
    [Table("study_titles", Schema = "mdr")]
    public class StudyTitle
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("sd_sid")]
        public string? SdSid { get; set; }
        
        [Column("title_type_id")]
        public int? TitleTypeId { get; set; }
        
        [Column("title_text")]
        public string? TitleText { get; set; }
        
        [Column("lang_code")]
        public string? LangCode { get; set; }
        
        [Column("lang_usage_id")]
        public int? LangUsageId { get; set; }
        
        [Column("is_default")]
        public bool? IsDefault { get; set; }
        
        [Column("comments")]
        public string? Comments { get; set; }
        
        [Column("created_on")]
        public DateTime? CreatedOn { get; set; }
    }
}