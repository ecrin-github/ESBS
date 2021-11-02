using Nest;

namespace MdrService.Models.Elasticsearch.Study
{
    public class MinAge
    {
        [Number(Name = "value")]
        #nullable enable
        public int? Value { get; set; }
        
        [Number(Name = "unit_id")]
        #nullable enable
        public int? UnitId { get; set; }
        
        [Text(Name = "unit_name")]
        #nullable enable
        public string? UnitName { get; set; }
    }
}