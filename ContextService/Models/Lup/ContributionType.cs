using System;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace ContextService.Models.Lup
{
    [Table("contribution_types", Schema = "lup")]
    public class ContributionType
    {
        [Column("id")]
        public int Id { get; set; }
        
        [Column("name")]
        public string? Name { get; set; }
        
        [Column("description")]
        public string? Description { get; set; }
        
        [Column("list_order")]
        public int ListOrder { get; set; }
        
        [Column("source")]
        public string? Source { get; set; }
        
        [Column("date_added", TypeName = "Date")]
        public DateTime? DateAdded { get; set; }
    }
}