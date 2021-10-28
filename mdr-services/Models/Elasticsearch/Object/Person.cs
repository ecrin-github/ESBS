using Nest;

namespace mdr_services.Models.Elasticsearch.Object
{
    public class Person
    {
        [Text(Name = "family_name")]
        #nullable enable
        public string? FamilyName { get; set; }
        
        [Text(Name = "given_name")]
        #nullable enable
        public string? GivenName { get; set; }
        
        [Text(Name = "full_name")]
        #nullable enable
        public string? FullName { get; set; }
        
        [Text(Name = "orcid")]
        #nullable enable
        public string? Orcid { get; set; }
        
        [Text(Name = "affiliation_string")]
        #nullable enable
        public string? AffiliationString { get; set; }
        
        [Number(Name = "affiliation_org_id")]
        #nullable enable
        public int? AffiliationOrgId { get; set; }
        
        [Text(Name = "affiliation_org_name")]
        #nullable enable
        public string? AffiliationOrgName { get; set; }
        
        [Text(Name = "affiliation_org_ror_id")]
        #nullable enable
        public string? AffiliationOrgRorId { get; set; }
    }
}