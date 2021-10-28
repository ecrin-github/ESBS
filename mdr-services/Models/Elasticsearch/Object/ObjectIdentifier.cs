using mdr_services.Models.Elasticsearch.Common;
using Nest;


namespace mdr_services.Models.Elasticsearch.Object
{
    public class ObjectIdentifier
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
        
        [Date(Name = "identifier_date", Format = "YYYY MMM dd")]
        #nullable enable
        public string? IdentifierDate { get; set; }
        
        [Text(Name = "identifier_org")]
        #nullable enable
        public IdentifierOrg? IdentifierOrg { get; set; }
    }
}