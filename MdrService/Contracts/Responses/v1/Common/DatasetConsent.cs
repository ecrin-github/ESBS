namespace MdrService.Contracts.Responses.v1.Common
{
    #nullable enable
    public class DatasetConsent
    {
        public int? ConsentTypeId { get; set; }
        
        public string? ConsentType { get; set; }
        
        public bool? ConsentNoncommercial { get; set; }
        
        public bool? ConsentGeogRestrict { get; set; }
        
        public bool? ConsentResearchType { get; set; }
        
        public bool? ConsentGeneticOnly { get; set; }
        
        public bool? ConsentNoMethods { get; set; }
        
        public string? ConsentsDetails { get; set; }
    }
}