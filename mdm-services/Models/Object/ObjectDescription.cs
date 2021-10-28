using System;
using LinqToDB.Mapping;

#nullable enable
namespace mdm_services.Models.Object
{
    [Table("object_descriptions", Schema = "mdr")]
    public class ObjectDescription
    {
        [PrimaryKey, Identity]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("sd_oid")]
        public string? SdOid { get; set; }
        
        [Column("description_type_id")]
        public int? DescriptionTypeId { get; set; }
        
        [Column("label")]
        public string? Label { get; set; }
        
        [Column("description_text")]
        public string? DescriptionText { get; set; }
        
        [Column("lang_code")]
        public string? LangCode { get; set; }
        
        [Column("created_on")]
        public DateTime? CreatedOn { get; set; }
    }
}