using System.ComponentModel.DataAnnotations.Schema;

namespace ContextService.Models.Lup
{
    [Table("geog_entity_types", Schema = "lup")]
    public class GeogEntityType
    {
        [Column("id")]
        public int Id { get; set; }
        
        [Column("name")]
        public string Name { get; set; }
        
        [Column("description")]
        public string Description { get; set; }
        
        [Column("list_order")]
        public int ListOrder { get; set; }
    }
}