using MdrService.Models.Elasticsearch.Common;
using Nest;

#nullable enable
namespace MdrService.Models.Elasticsearch.Object
{
    public class ObjectTitle
    {
        [Number(Name = "id")]
        public int? Id { get; set; }
        
        [Object]
        [PropertyName("title_type")]
        public TitleType? TitleType { get; set; }
        
        [Text(Name = "title_text")]
        public string? TitleText { get; set; }
        
        [Text(Name = "lang_code")]
        public string? LangCode { get; set; }
        
        [Text(Name = "comments")]
        public string? Comments { get; set; }
    }
}