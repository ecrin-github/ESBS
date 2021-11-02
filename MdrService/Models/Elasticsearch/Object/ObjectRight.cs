using Nest;

namespace MdrService.Models.Elasticsearch.Object
{
    public class ObjectRight
    {
        [Number(Name = "id")]
        #nullable enable
        public int? Id { get; set; }
        
        [Text(Name = "rights_name")]
        #nullable enable
        public string? RightsName { get; set; }
        
        [Text(Name = "rights_url")]
        #nullable enable
        public string? RightsUrl { get; set; }
        
        [Text(Name = "comments")]
        #nullable enable
        public string? Comments { get; set; }
    }
}