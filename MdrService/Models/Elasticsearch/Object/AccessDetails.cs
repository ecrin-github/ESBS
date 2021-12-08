using Nest;

#nullable enable
namespace MdrService.Models.Elasticsearch.Object
{
    public class AccessDetails
    {
        [Text(Name = "description")]
        public string? Description { get; set; }
        
        [Text(Name = "url")]
        public string? Url { get; set; }
        
        [Date(Name = "url_last_checked", Format = "YYYY MM DD")]
        public string? UrlLastChecked { get; set; }
    }
}