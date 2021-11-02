using Nest;

namespace MdrService.Models.Elasticsearch.Object
{
    public class InstanceAccessDetails
    {
        [Boolean(Name = "direct_access")]
        #nullable enable
        public bool? DirectAccess { get; set; }
        
        [Text(Name = "url")]
        #nullable enable
        public string? Url { get; set; }
        
        [Date(Name = "url_last_checked", Format = "YYYY MMM dd")]
        #nullable enable
        public string? UrlLastChecked { get; set; }
    }
}