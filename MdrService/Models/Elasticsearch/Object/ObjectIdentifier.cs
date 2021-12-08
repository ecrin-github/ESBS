using MdrService.Models.Elasticsearch.Common;
using Nest;

#nullable enable
namespace MdrService.Models.Elasticsearch.Object
{
    public class ObjectIdentifier
    {
        [Number(Name = "id")]
        public int? Id { get; set; }
        
        [Text(Name = "identifier_value")]
        public string? IdentifierValue { get; set; }
        
        [Object]
        [PropertyName("identifier_type")]
        public IdentifierType? IdentifierType { get; set; }
        
        [Date(Name = "identifier_date", Format = "YYYY MMM dd")]
        public string? IdentifierDate { get; set; }
        
        [Text(Name = "identifier_org")]
        public IdentifierOrg? IdentifierOrg { get; set; }
    }
}