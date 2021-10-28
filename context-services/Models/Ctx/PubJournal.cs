using LinqToDB.Mapping;

namespace context_services.Models.Ctx
{
    [Table("pub_journals", Schema = "ctx")]
    public class PubJournal
    {
        [Column("journal_name")]
        public string JournalName { get; set; }
        
        [Column("pub_id")]
        public int PubId { get; set; }
    }
}