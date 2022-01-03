using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace ContextService.Models.Ctx
{
    [Table("to_match_orgs", Schema = "ctx")]
    public class ToMatchOrg
    {
        [Column("source_id")]
        public int? SourceId {get; set;}

        [Column("source_table")]
        public string? SourceTable {get; set;}

        [Column("org_name")]
        public string? OrgName {get; set;}

        [Column("number_of")]
        public int? NumberOf {get; set;}
    }
}