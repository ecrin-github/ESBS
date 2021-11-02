using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable enable
namespace ContextService.Models.Ctx
{
    [Table("pub_eissns", Schema = "ctx")]
    [Keyless]
    public class PubEissn
    {
        [Column("eissn")]
        public string? Eissn { get; set; }
        
        [Column("pub_id")]
        public int PubId { get; set; }
    }
}