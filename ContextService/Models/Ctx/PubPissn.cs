using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable enable
namespace ContextService.Models.Ctx
{
    [Table("pub_pissns", Schema = "ctx")]
    [Keyless]
    public class PubPissn
    {
        [Column("pissn")]
        public string? Pissn { get; set; }
        
        [Column("pub_id")]
        public int PubId { get; set; }
    }
}