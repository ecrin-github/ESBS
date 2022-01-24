using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace MdmService.Models.Object
{
    [Table("object_contributors", Schema = "mdr")]
    public class ObjectContributor
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("sd_oid")]
        public string? SdOid { get; set; }
        
        [Column("contrib_type_id")]
        public int? ContribTypeId { get; set; }
        
        [Column("is_individual")]
        public bool? IsIndividual { get; set; }
        
        [Column("person_id")]
        public int? PersonId { get; set; }
        
        [Column("person_given_name")]
        public string? PersonGivenName { get; set; }
        
        [Column("person_family_name")]
        public string? PersonFamilyName { get; set; }
        
        [Column("person_full_name")]
        public string? PersonFullName { get; set; }
        
        [Column("orcid_id")]
        public string? OrcidId { get; set; }
        
        [Column("person_affiliation")]
        public string? PersonAffiliation { get; set; }
        
        [Column("organisation_id")]
        public int? OrganisationId { get; set; }
        
        [Column("organisation_name")]
        public string? OrganisationName { get; set; }
        
        [Column("organisation_ror_id")]
        public string? OrganisationRorId { get; set; }
        
        [Column("created_on")]
        public DateTime? CreatedOn { get; set; }

        [Column("last_edited_by")]
        public string? LastEditedBy {get; set;}
    }
}