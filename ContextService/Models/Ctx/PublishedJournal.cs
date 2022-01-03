using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable enable
namespace ContextService.Models.Ctx
{
    [Table("published_journals", Schema = "ctx")]
    [Keyless]
    public class PublishedJournal
    {
        [Column("journal_title")]
        public string? JournalTitle {get; set;}

        [Column("journal_id")]
        public int JournalId { get; set; }

        [Column("publisher")]
        public string? Publisher {get; set;}

        [Column("publisher_id")]
        public int? PublisherId { get; set; }

        [Column("eissn")]
        public string? Eissn {get; set;}

        [Column("pissn")]
        public string? Pissn {get; set;}

        [Column("additional_issns")]
        public string? AdditionalIssns {get; set;}
        
        [Column("doi")]
        public string? Doi {get; set;}
    }
}