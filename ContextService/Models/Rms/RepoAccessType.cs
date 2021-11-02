using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace ContextService.Models.Rms
{
    [Table("repo_access_types", Schema = "rms")]
    public class RepoAccessType
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("name")]
        public string? Name { get; set; }
        
        [Column("description")]
        public string? Description { get; set; }
        
        [Column("list_order")]
        public int? ListOrder { get; set; }
        
        [Column("created_on")]
        public DateTime? CreatedOn { get; set; }
    }
}