using Nest;

#nullable enable
namespace MdrService.Models.Elasticsearch.Object
{
    public class ContributionType
    {
        [Number(Name = "id")]
        public int? Id { get; set; }
        
        [Text(Name = "name")]
        public string? Name { get; set; }
    }
}