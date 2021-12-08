using Nest;

#nullable enable
namespace MdrService.Models.Elasticsearch.Object
{
    public class Person
    {
        [Text(Name = "family_name")]
        public string? FamilyName { get; set; }
        
        [Text(Name = "given_name")]
        public string? GivenName { get; set; }
        
        [Text(Name = "full_name")]
        public string? FullName { get; set; }
        
        [Text(Name = "orcid")]
        public string? Orcid { get; set; }
        
        [Text(Name = "affiliation_string")]
        public string? AffiliationString { get; set; }
        
        [Number(Name = "affiliation_org_id")]
        public int? AffiliationOrgId { get; set; }
        
        [Text(Name = "affiliation_org_name")]
        public string? AffiliationOrgName { get; set; }
        
        [Text(Name = "affiliation_org_ror_id")]
        public string? AffiliationOrgRorId { get; set; }
    }
}