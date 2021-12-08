using Nest;

#nullable enable
namespace MdrService.Models.Elasticsearch.Common
{
    public class IdentifierType
    {
        [Number(Name = "id")]
        public int? Id { get; set; }
        
        [Text(Name = "name")]
        public string? Name { get; set; }
    }
}