using System;
using LinqToDB.Mapping;

#nullable enable
namespace rms_services.Models
{
    [Table("process_notes", Schema = "rms")]
    public class ProcessNote
    {
        [PrimaryKey, Identity]
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