using System;
using LinqToDB.Mapping;

#nullable enable
namespace mdm_services.Models.Object
{
    [Table("object_relationships", Schema = "mdr")]
    public class ObjectRelationship
    {
        [PrimaryKey, Identity]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("sd_oid")]
        public string? SdOid { get; set; }
        
        [Column("relationship_type_id")]
        public int? RelationshipTypeId { get; set; }
        
        [Column("target_sd_oid")]
        public string? TargetSdOid { get; set; }
        
        [Column("created_on")]
        public DateTime? CreatedOn { get; set; }
    }
}