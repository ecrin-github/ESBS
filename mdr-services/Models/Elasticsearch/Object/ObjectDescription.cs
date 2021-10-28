using Nest;

namespace mdr_services.Models.Elasticsearch.Object
{
    public class ObjectDescription
    {
        [Number(Name = "id")]
        #nullable enable
        public int? Id { get; set; }
        
        [Object]
        [PropertyName("description_type")]
        #nullable enable
        public DescriptionType? DescriptionType { get; set; }
        
        [Text(Name = "description_label")]
        #nullable enable
        public string? DescriptionLabel { get; set; }
        
        [Text(Name = "description_text")]
        #nullable enable
        public string? DescriptionText { get; set; }
        
        [Text(Name = "lang_code")]
        #nullable enable
        public string? LangCode { get; set; }
    }
}