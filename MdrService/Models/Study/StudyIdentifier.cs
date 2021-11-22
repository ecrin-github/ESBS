using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace MdrService.Models.Study
{
    [Table("study_identifiers", Schema = "core")]
    public class StudyIdentifier
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("study_id")]
        public int StudyId { get; set; }
        
        [Column("identifier_value")]
        public string? IdentifierValue { get; set; }
        
        [Column("identifier_type_id")]
        public int? IdentifierTypeId { get; set; }
        
        [Column("identifier_org_id")]
        public int? IdentifierOrgId { get; set; }
        
        [Column("identifier_org")]
        public string? IdentifierOrg { get; set; }

        [Column("identifier_org_ror_id")]
        public string? IdentifierOrgRorId { get; set; }
        
        [Column("identifier_date")]
        public string? IdentifierDate { get; set; }
        
        [Column("identifier_link")]
        public string? IdentifierLink { get; set; }
    }
}