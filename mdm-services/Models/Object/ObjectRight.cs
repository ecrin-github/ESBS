using System;
using LinqToDB.Mapping;

#nullable enable
namespace mdm_services.Models.Object
{
    [Table("object_rights", Schema = "mdr")]
    public class ObjectRight
    {
        [PrimaryKey, Identity]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("sd_oid")]
        public string? SdOid { get; set; }
        
        [Column("rights_name")]
        public string? RightsName { get; set; }
        
        [Column("rights_uri")]
        public string? RightsUri { get; set; }
        
        [Column("comments")]
        public string? Comments { get; set; }
        
        [Column("created_on")]
        public DateTime? CreatedOn { get; set; }
    }
}