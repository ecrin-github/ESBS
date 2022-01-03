using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace ContextService.Models.Lup
{
    [Table("org_types", Schema = "lup")]
    public class OrgType
    {
        [Column("id")]
        public int Id {get; set;}

        [Column("name")]
        public string? Name {get; set;}

        [Column("class_id")]
        public int? ClassId {get; set;}
    }
}