using Nest;

namespace mdr_services.Models.Elasticsearch.Object
{
    public class AccessDetails
    {
        [Text(Name = "description")]
        #nullable enable
        public string? Description { get; set; }
        
        [Text(Name = "url")]
        #nullable enable
        public string? Url { get; set; }
        
        [Date(Name = "url_last_checked", Format = "YYYY MM DD")]
        #nullable enable
        public string? UrlLastChecked { get; set; }
    }
}