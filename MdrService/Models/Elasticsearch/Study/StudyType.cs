using Nest;

namespace MdrService.Models.Elasticsearch.Study
{
    public class StudyType
    {
        [Number(Name = "id")]
        #nullable enable
        public int? Id { get; set; }
        
        [Text(Name = "name")]
        #nullable enable
        public string? Name { get; set; }
    }
}