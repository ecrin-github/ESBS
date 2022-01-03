using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace ContextService.Models.Ctx
{
    [Table("mesh_lookup", Schema = "ctx")]
    public class MeshLookup
    {
        [Column("entry")]
        public string? Entry {get; set;}

        [Column("code")]
        public string? Code {get; set;}

        [Column("term")]
        public string? Term {get; set;}

        [Column("source")]
        public string? Source {get; set;}
    }
}