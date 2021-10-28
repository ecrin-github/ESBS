using LinqToDB.Mapping;

namespace context_services.Models.Lup
{
    [Table("role_types", Schema = "lup")]
    public class RoleType
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