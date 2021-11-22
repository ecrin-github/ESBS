using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace MdrService.Models.Study
{
    [Table("study_titles", Schema = "core")]
    public class StudyTitle
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("study_id")]
        public int StudyId { get; set; }
        
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
    }
}