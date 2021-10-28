using System;
using LinqToDB.Mapping;

#nullable enable
namespace rms_services.Models
{
    [Table("dup_objects", Schema = "rms")]
    public class DupObject
    {
        [PrimaryKey, Identity]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("dup_id")]
        public int DupId { get; set; }
        
        [Column("object_id")]
        public string? ObjectId { get; set; }
        
        [Column("access_type_id")]
        public int? AccessTypeId { get; set; }
        
        [Column("access_details")]
        public string? AccessDetails { get; set; }
        
        [Column("notes")]
        public string? Notes { get; set; }
        
        [Column("created_on")]
        public DateTime? CreatedOn { get; set; }
    }
}