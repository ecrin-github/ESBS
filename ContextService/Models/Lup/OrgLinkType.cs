using System;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace ContextService.Models.Lup
{
    [Table("org_link_types", Schema = "lup")]
    public class OrgLinkType
    {
        [Column("id")]
        public int Id {get; set;}

        [Column("name")]
        public string? Name {get; set;}

        [Column("description")]
        public string? Description {get; set;}

        [Column("list_order")]
        public int? ListOrder {get; set;}

        [Column("created_on", TypeName = "Date")]
        public DateTime? CreatedOn {get; set;}
    }
}