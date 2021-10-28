using LinqToDB.Mapping;

namespace context_services.Models.Lup
{
    [Table("rms_user_types", Schema = "lup")]
    public class RmsUserType
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