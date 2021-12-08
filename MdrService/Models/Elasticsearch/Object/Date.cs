using Nest;

#nullable enable
namespace MdrService.Models.Elasticsearch.Object
{
    public class Date
    {
        [Number(Name = "year")]
        public int? Year { get; set; }
        
        [Number(Name = "month")]
        public int? Month { get; set; }
        
        [Number(Name = "day")]
        public int? Day { get; set; }
    }
}