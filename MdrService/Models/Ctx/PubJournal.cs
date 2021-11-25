using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable enable
namespace MdrService.Models.Ctx
{
    [Table("pub_journals", Schema = "ctx")]
    [Keyless]
    public class PubJournal
    {
        [Column("journal_name")]
        public string? JournalName { get; set; }
        
        [Column("pub_id")]
        public int PubId { get; set; }
    }
}