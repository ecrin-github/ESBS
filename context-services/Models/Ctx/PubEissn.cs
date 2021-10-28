using LinqToDB.Mapping;

namespace context_services.Models.Ctx
{
    [Table("pub_eissns", Schema = "ctx")]
    public class PubEissn
    {
        [Column("eissn")]
        public string Eissn { get; set; }
        
        [Column("pub_id")]
        public int PubId { get; set; }
    }
}