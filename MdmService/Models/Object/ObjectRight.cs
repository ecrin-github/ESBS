using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace MdmService.Models.Object
{
    [Table("object_rights", Schema = "mdr")]
    public class ObjectRight
    {
        [Key]
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

        [Column("last_edited_by")]
        public string? LastEditedBy {get; set;}
    }
}