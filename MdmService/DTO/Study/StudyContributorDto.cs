using System;

#nullable enable
namespace MdmService.DTO.Study
{
    public class StudyContributorDto
    {
        public int? Id { get; set; }
        
        public string? SdSid { get; set; }
        
        public int? ContribTypeId { get; set; }
        
        public bool? IsIndividual { get; set; }
        
        public int? PersonId { get; set; }
        
        public string? PersonGivenName { get; set; }
        
        public string? PersonFamilyName { get; set; }
        
        public string? PersonFullName { get; set; }
        
        public string? OrcidId { get; set; }
        
        public string? PersonAffiliation { get; set; }
        
        public int? OrganisationId { get; set; }
        
        public string? OrganisationName { get; set; }
        
        public string? OrganisationRorId { get; set; }
        
        public DateTime? CreatedOn { get; set; }
    }
}