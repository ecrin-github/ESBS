using mdr_services.Models.Elasticsearch.Common;
using Nest;

namespace mdr_services.Models.Elasticsearch.Study
{
    public class StudyTitle
    {
        [Number(Name = "id")]
        #nullable enable
        public int? Id { get; set; }
        
        [Object]
        [PropertyName("title_type")]
        #nullable enable
        public TitleType? TitleType { get; set; }
        
        [Text(Name = "title_text")]
        #nullable enable
        public string? TitleText { get; set; }
        
        [Text(Name = "lang_code")]
        #nullable enable
        public string? LangCode { get; set; }
        
        [Text(Name = "comments")]
        #nullable enable
        public string? Comments { get; set; }
    }
}