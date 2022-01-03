#nullable enable
using System.ComponentModel.DataAnnotations.Schema;

namespace ContextService.Models.Lup
{
    [Table("org_attribute_types", Schema = "lup")]
    public class OrgAttributeType
    {
        [Column("id")]
        public int Id {get; set;}

        [Column("name")]
        public string? Name {get; set;}

        [Column("type_id")]
        public int TypeId {get; set;}

        [Column("description")]
        public string? Description {get; set;}

        [Column("can_repeat")]
        public bool CanRepeat {get; set;}

        [Column("parent_id")]
        public int ParentId {get; set;}

        [Column("public")]
        public bool Public {get; set;}
    }
}