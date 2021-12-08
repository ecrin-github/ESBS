using Nest;

#nullable enable
namespace MdrService.Models.Elasticsearch.Study
{
    public class StudyType
    {
        [Number(Name = "id")]
        public int? Id { get; set; }
        
        [Text(Name = "name")]
        public string?Name { get; set; }
    }
}