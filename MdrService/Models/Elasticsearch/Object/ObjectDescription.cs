using Nest;

#nullable enable
namespace MdrService.Models.Elasticsearch.Object
{
    public class ObjectDescription
    {
        [Number(Name = "id")]
        public int? Id { get; set; }
        
        [Object]
        [PropertyName("description_type")]
        public DescriptionType? DescriptionType { get; set; }
        
        [Text(Name = "description_label")]
        public string? DescriptionLabel { get; set; }
        
        [Text(Name = "description_text")]
        public string? DescriptionText { get; set; }
        
        [Text(Name = "lang_code")]
        public string? LangCode { get; set; }
    }
}