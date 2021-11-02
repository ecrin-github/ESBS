using Nest;

namespace MdrService.Models.Elasticsearch.Object
{
    public class ObjectDate
    {
        [Number(Name = "id")]
        #nullable enable
        public int? Id { get; set; }
        
        [Object]
        [PropertyName("date_type")]
        #nullable enable
        public DateType? DateType { get; set; }
        
        [Boolean(Name = "date_is_range")]
        #nullable enable
        public bool? DateIsRange { get; set; }
        
        [Text(Name = "date_as_string")]
        #nullable enable
        public string? DateAsString { get; set; }
        
        [Object]
        [PropertyName("start_date")]
        #nullable enable
        public Date? StartDate { get; set; }
        
        [Object]
        [PropertyName("end_date")]
        #nullable enable
        public Date? EndDate { get; set; }
        
        [Text(Name = "comments")]
        #nullable enable
        public string? Comments { get; set; }
    }
}