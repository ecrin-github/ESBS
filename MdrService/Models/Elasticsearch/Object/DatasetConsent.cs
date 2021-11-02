using Nest;

namespace MdrService.Models.Elasticsearch.Object
{
    public class DatasetConsent
    {
        [Number(Name = "consent_type_id")]
        #nullable enable
        public int? ConsentTypeId { get; set; }
        
        [Text(Name = "consent_type")]
        #nullable enable
        public string? ConsentType { get; set; }
        
        [Boolean(Name = "consent_noncommercial")]
        #nullable enable
        public bool? ConsentNoncommercial { get; set; }
        
        [Boolean(Name = "consent_geog_restrict")]
        #nullable enable
        public bool? ConsentGeogRestrict { get; set; }
        
        [Boolean(Name = "consent_research_type")]
        #nullable enable
        public bool? ConsentResearchType { get; set; }
        
        [Boolean(Name = "consent_genetic_only")]
        #nullable enable
        public bool? ConsentGeneticOnly { get; set; }
        
        [Boolean(Name = "consent_no_methods")]
        #nullable enable
        public bool? ConsentNoMethods { get; set; }
        
        [Text(Name = "consents_details")]
        #nullable enable
        public string? ConsentsDetails { get; set; }
    }
}