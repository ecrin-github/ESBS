using MdrService.Models.Elasticsearch.Common;
using Nest;

namespace MdrService.Models.Elasticsearch.Study
{
    public class StudyIdentifier
    {
        [Number(Name = "id")]
        #nullable enable
        public int? Id { get; set; }
        
        [Text(Name = "identifier_value")]
        #nullable enable
        public string? IdentifierValue { get; set; }
        
        [Object]
        [PropertyName("identifier_type")]
        #nullable enable
        public IdentifierType? IdentifierType { get; set; }
        
        [Date(Name = "identifier_date", Format = "yyyy MM dd")]
        #nullable enable
        public string? IdentifierDate { get; set; }
        
        [Text(Name = "identifier_link")]
        #nullable enable
        public string? IdentifierLink { get; set; }
        
        [Object]
        [PropertyName("identifier_org")]
        #nullable enable
        public IdentifierOrg? IdentifierOrg { get; set; }
    }
}