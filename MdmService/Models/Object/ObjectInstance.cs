using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace MdmService.Models.Object
{
    [Table("object_instances", Schema = "mdr")]
    public class ObjectInstance
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("sd_oid")]
        public string? SdOid { get; set; }
        
        [Column("instance_type_id")]
        public int? InstanceTypeId { get; set; }
        
        [Column("repository_org_id")]
        public int? RepositoryOrgId { get; set; }
        
        [Column("repository_org")]
        public string? RepositoryOrg { get; set; }
        
        [Column("url")]
        public string? Url { get; set; }
        
        [Column("url_accessible")]
        public bool? UrlAccessible { get; set; }
        
        [Column("url_last_checked", TypeName = "Date")]
        public DateTime? UrlLastChecked { get; set; }
        
        [Column("resource_type_id")]
        public int? ResourceTypeId { get; set; }
        
        [Column("resource_size")]
        public string? ResourceSize { get; set; }
        
        [Column("resource_size_units")]
        public string? ResourceSizeUnits { get; set; }
        
        [Column("resource_comments")]
        public string? ResourceComments { get; set; }

        [Column("created_on")]
        public DateTime? CreatedOn { get; set; }

        [Column("last_edited_by")]
        public string? LastEditedBy {get; set;}
    }
}