using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace MdrService.Models.Ctx
{
    [Table("org_attributes", Schema = "ctx")]
    public class OrgAttribute
    {
        [Key]
        public int Id { get; set; }
        
        [Column("org_id")]
        public int OrgId { get; set; }
        
        [Column("default_name")]
        public string? DefaultName { get; set; }
        
        [Column("attribute_type_id")]
        public int AttributeTypeId { get; set; }
        
        [Column("attribute_string_value")]
        public string? AttributeStringValue { get; set; }
        
        [Column("attribute_boolean_value")]
        public bool AttributeBooleanValue { get; set; }
        
        [Column("attribute_integer_value")]
        public int AttributeIntegerValue { get; set; }
        
        [Column("attribute_float_value")]
        public float AttributeFloatValue { get; set; }
        
        [Column("attribute_date_value")]
        public DateTime? AttributeDateValue { get; set; }
        
        [Column("created_on")]
        public DateTime? CreatedOn { get; set; }
    }
}