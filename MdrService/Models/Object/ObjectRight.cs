using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace MdrService.Models.Object
{
    [Table("object_rights", Schema = "core")]
    public class ObjectRight
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("object_id")]
        public int ObjectId { get; set; }
        
        [Column("rights_name")]
        public string? RightsName { get; set; }
        
        [Column("rights_uri")]
        public string? RightsUri { get; set; }
        
        [Column("comments")]
        public string? Comments { get; set; }
    }
}