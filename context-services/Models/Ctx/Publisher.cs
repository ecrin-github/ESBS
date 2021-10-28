using LinqToDB.Mapping;

namespace context_services.Models.Ctx
{
    [Table("publishers", Schema = "ctx")]
    public class Publisher
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }
        
        [Column("publisher")]
        public string PublisherName { get; set; }
        
        [Column("org_id")]
        public int OrgId { get; set; }
        
        [Column("org_name")]
        public string OrgName { get; set; }
        
        [Column("org_display_suffix")]
        public string OrgDisplaySuffix { get; set; }
    }
}