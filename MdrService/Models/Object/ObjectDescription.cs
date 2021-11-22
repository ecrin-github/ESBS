using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace MdrService.Models.Object
{
    [Table("object_descriptions", Schema = "core")]
    public class ObjectDescription
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("object_id")]
        public int ObjectId { get; set; }
        
        [Column("description_type_id")]
        public int? DescriptionTypeId { get; set; }
        
        [Column("label")]
        public string? Label { get; set; }
        
        [Column("description_text")]
        public string? DescriptionText { get; set; }
        
        [Column("lang_code")]
        public string? LangCode { get; set; }
    }
}