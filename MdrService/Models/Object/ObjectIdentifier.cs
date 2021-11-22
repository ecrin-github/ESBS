using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace MdrService.Models.Object
{
    [Table("object_identifiers", Schema = "core")]
    public class ObjectIdentifier
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("object_id")]
        public int ObjectId { get; set; }
        
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
    }
}