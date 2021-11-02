using MdrService.Models.Elasticsearch.Common;

#nullable enable
namespace MdrService.Contracts.Responses.v1.ObjectListResponse
{
    public class ObjectIdentifierListResponse
    {
        public int? Id { get; set; }
        
        public string? IdentifierValue { get; set; }
        
        public string? IdentifierType { get; set; }
        
        public string? IdentifierDate { get; set; }
        
        public IdentifierOrg? IdentifierOrg { get; set; }
    }
}