
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace ContextService.Models.Lup
{
    [Table("org_relationship_types", Schema = "lup")]
    public class OrgRelationshipType
    {
        [Column("id")]
        public int Id {get; set;}

        [Column("name")]
        public string? Name {get; set;}

        [Column("list_order")]
        public int? ListOrder {get; set;}
    }
}