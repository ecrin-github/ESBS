using Nest;

#nullable enable
namespace MdrService.Models.Elasticsearch.Object
{
    public class InstanceAccessDetails
    {
        [Boolean(Name = "direct_access")]
        public bool? DirectAccess { get; set; }
        
        [Text(Name = "url")]
        public string? Url { get; set; }
        
        [Date(Name = "url_last_checked", Format = "YYYY MMM dd")]
        public string? UrlLastChecked { get; set; }
    }
}