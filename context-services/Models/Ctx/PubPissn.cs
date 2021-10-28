using LinqToDB.Mapping;

namespace context_services.Models.Ctx
{
    [Table("pub_pissns", Schema = "ctx")]
    public class PubPissn
    {
        [Column("pissn")]
        public string Pissn { get; set; }
        
        [Column("pub_id")]
        public int PubId { get; set; }
    }
}