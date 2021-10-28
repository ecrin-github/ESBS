using System;
using LinqToDB.Mapping;

#nullable enable
namespace mdm_services.Models.Object
{
    [Table("object_topics", Schema = "mdr")]
    public class ObjectTopic
    {
        [PrimaryKey, Identity]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("sd_oid")]
        public string? SdOid { get; set; }
        
        [Column("topic_type_id")]
        public int? TopicTypeId { get; set; }
        
        [Column("mesh_coded")]
        public bool? MeshCoded { get; set; }
        
        [Column("mesh_code")]
        public string? MeshCode { get; set; }
        
        [Column("mesh_value")]
        public string? MeshValue { get; set; }
        
        [Column("mesh_qualcode")]
        public string? MeshQualcode { get; set; }
        
        [Column("mesh_qualvalue")]
        public string? MeshQualvalue { get; set; }
        
        [Column("original_ct_id")]
        public int? OriginalCtId { get; set; }
        
        [Column("original_ct_code")]
        public string? OriginalCtCode { get; set; }
        
        [Column("original_value")]
        public string? OriginalValue { get; set; }
        
        [Column("comments")]
        public string? Comments { get; set; }
        
        [Column("created_on")]
        public DateTime? CreatedOn { get; set; }
    }
}