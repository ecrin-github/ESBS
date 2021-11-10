using Nest;

namespace MdrService.Models.Elasticsearch.Object
{
    public class AccessDetails
    {
        [Text(Name = "description")]
        #nullable enable
        public string? Description { get; set; }
        
        [Text(Name = "url")]
        #nullable enable
        public string? Url { get; set; }
        
        [Date(Name = "url_last_checked", Format = "yyyy MM dd")]
        #nullable enable
        public string? UrlLastChecked { get; set; }
    }
}