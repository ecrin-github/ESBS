namespace MdrService.Contracts.Responses.v1.Common
{
    #nullable enable
    public class Person
    {
        public string? FamilyName { get; set; }
        
        public string? GivenName { get; set; }
        
        public string? FullName { get; set; }
        
        public string? Orcid { get; set; }
        
        public string? AffiliationString { get; set; }
        
        public int? AffiliationOrgId { get; set; }
        
        public string? AffiliationOrgName { get; set; }
        
        public string? AffiliationOrgRorId { get; set; }
    }
}