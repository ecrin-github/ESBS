using System;
using LinqToDB.Mapping;

namespace context_services.Models.Ctx
{
    [Table("org_links", Schema = "ctx")]
    public class OrgLink
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }
        
        [Column("org_id")]
        public int OrgId { get; set; }
        
        [Column("default_name")]
        public string DefaultName { get; set; }
        
        [Column("org_link_type_id")]
        public int OrgLinkTypeId { get; set; }
        
        [Column("link")]
        public string Link { get; set; }
        
        [Column("created_on")]
        public DateTime CreatedOn { get; set; }
    }
}