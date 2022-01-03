using System;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace ContextService.Models.Ctx
{
    [Table("org_type_membership", Schema = "ctx")]
    public class OrgTypeMembership
    {
        [Column("id")]
        public int Id {get; set;}

        [Column("org_id")]
        public int OrgId {get; set;}

        [Column("default_name")]
        public string? DefaultName {get; set;}

        [Column("org_type_id")]
        public int? OrgTypeId {get; set;}

        [Column("notes")]
        public string? Notes {get; set;}

        [Column("created_on")]
        public DateTime? CreatedOn {get; set;}
    }
}