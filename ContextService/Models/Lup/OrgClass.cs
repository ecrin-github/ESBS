using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace ContextService.Models.Lup
{
    [Table("org_classes", Schema = "lup")]
    public class OrgClass
    {
        [Column("id")]
        public int Id {get; set;}

        [Column("name")]
        public string? Name {get; set;}

        [Column("list_order")]
        public int? ListOrder {get; set;}
    }
}