using System;
using LinqToDB.Mapping;

#nullable enable
namespace rms_services.Models
{
    [Table("duas", Schema = "rms")]
    public class Dua
    {
        [PrimaryKey, Identity]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("dup_id")]
        public int DupId { get; set; }
        
        [Column("conforms_to_default")]
        public int? ConformsToDefault { get; set; }
        
        [Column("variations")]
        public string? Variations { get; set; }
        
        [Column("repo_as_proxy")]
        public bool? RepoAsProxy { get; set; }
        
        [Column("repo_signatory_1")]
        public int? RepoSignatory1 { get; set; }
        
        [Column("repo_signatory_2")]
        public int? RepoSignatory2 { get; set; }
        
        [Column("provider_signatory_1")]
        public int? ProviderSignatory1 { get; set; }
        
        [Column("provider_signatory_2")]
        public int? ProviderSignatory2 { get; set; }
        
        [Column("requester_signatory_1")]
        public int? RequesterSignatory1 { get; set; }
        
        [Column("requester_signatory_2")]
        public int? RequesterSignatory2 { get; set; }
        
        [Column("notes")]
        public string? Notes { get; set; }
        
        [Column("created_on")]
        public DateTime? CreatedOn { get; set; }
    }
}