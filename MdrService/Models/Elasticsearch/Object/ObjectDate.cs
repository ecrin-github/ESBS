using Nest;

#nullable enable
namespace MdrService.Models.Elasticsearch.Object
{
    public class ObjectDate
    {
        [Number(Name = "id")]
        public int? Id { get; set; }
        
        [Object]
        [PropertyName("date_type")]
        public DateType? DateType { get; set; }
        
        [Boolean(Name = "date_is_range")]
        public bool? DateIsRange { get; set; }
        
        [Text(Name = "date_as_string")]
        public string? DateAsString { get; set; }
        
        [Object]
        [PropertyName("start_date")]
        public Date? StartDate { get; set; }
        
        [Object]
        [PropertyName("end_date")]
        public Date? EndDate { get; set; }
        
        [Text(Name = "comments")]
        public string? Comments { get; set; }
    }
}