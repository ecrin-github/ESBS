using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace MdmService.Models.Study
{
    [Table("study_identifiers", Schema = "mdr")]
    public class StudyIdentifier
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("sd_sid")]
        public string? SdSid { get; set; }
        
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
        
        [Column("created_on")]
        public DateTime? CreatedOn { get; set; }
    }
}