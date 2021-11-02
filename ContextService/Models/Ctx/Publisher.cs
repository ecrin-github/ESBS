using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace ContextService.Models.Ctx
{
    [Table("publishers", Schema = "ctx")]
    public class Publisher
    {
        [Key]
        public int Id { get; set; }
        
        [Column("publisher")]
        public string? PublisherName { get; set; }
        
        [Column("org_id")]
        public int OrgId { get; set; }
        
        [Column("org_name")]
        public string? OrgName { get; set; }
        
        [Column("org_display_suffix")]
        public string? OrgDisplaySuffix { get; set; }
    }
}