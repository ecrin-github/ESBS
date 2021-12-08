using Nest;

#nullable enable
namespace MdrService.Models.Elasticsearch.Common
{
    public class IdentifierOrg
    {
        [Number(Name = "id")]
        public int? Id { get; set; }
        
        [Text(Name = "name")]
        public string? Name { get; set; }
        
        [Text(Name = "ror_id")]
        public string? RorId { get; set; }
    }
}