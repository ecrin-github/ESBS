using System;
using LinqToDB.Mapping;

#nullable enable
namespace rms_services.Models
{
    [Table("secondary_use", Schema = "rms")]
    public class SecondaryUse
    {
        [PrimaryKey, Identity]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("dup_id")]
        public int DupId { get; set; }
        
        [Column("secondary_use_type")]
        public string? SecondaryUseType { get; set; }
        
        [Column("publication")]
        public string? Publication { get; set; }
        
        [Column("doi")]
        public string? Doi { get; set; }
        
        [Column("attribution_present")]
        public bool? AttributionPresent { get; set; }
        
        [Column("notes")]
        public string? Notes { get; set; }
        
        [Column("created_on")]
        public DateTime? CreatedOn { get; set; }
    }
}