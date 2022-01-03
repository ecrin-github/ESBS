using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace ContextService.Models.Ctx
{
    [Table("geog_entities", Schema = "ctx")]
    public class GeogEntity
    {
        [Column("id")]
        public int Id {get; set;}

        [Column("type_id")]
        public int? TypeId {get; set;}

        [Column("name")]
        public string? Name {get; set;}

        [Column("code")]
        public string? Code {get; set;}

        [Column("parent_id")]
        public int? ParentId {get; set;}

        [Column("parent")]
        public string? Parent {get; set;}

        [Column("old_id")]
        public int? OldId {get; set;}
    }
}