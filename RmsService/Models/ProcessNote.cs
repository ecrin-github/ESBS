using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace RmsService.Models
{
    [Table("process_notes", Schema = "rms")]
    public class ProcessNote
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("process_type")]
        public int? ProcessType { get; set; }
        
        [Column("process_id")]
        public int? ProcessId { get; set; }
        
        [Column("text")]
        public string? Text { get; set; }
        
        [Column("author")]
        public int? Author { get; set; }
        
        [Column("created_on")]
        public DateTime? CreatedOn { get; set; }
    }
}