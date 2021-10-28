using System;
using LinqToDB.Mapping;

#nullable enable
namespace rms_services.Models
{
    [Table("process_people", Schema = "rms")]
    public class ProcessPeople
    {
        [PrimaryKey, Identity]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("process_type")]
        public int? ProcessType { get; set; }
        
        [Column("process_id")]
        public int? ProcessId { get; set; }
        
        [Column("person_id")]
        public int? PersonId { get; set; }
        
        [Column("is_a_user")]
        public bool? IsAUser { get; set; }
        
        [Column("notes")]
        public string? Notes { get; set; }
        
        [Column("created_on")]
        public DateTime CreatedOn { get; set; }
    }
}