using mdr_services.Models.Elasticsearch.Object;

#nullable enable
namespace mdr_services.Contracts.Responses.v1.ObjectListResponse
{
    public class ObjectDateListResponse
    {
        public int? Id { get; set; }
        
        public string? DateType { get; set; }
        
        public bool? DateIsRange { get; set; }
        
        public string? DateAsString { get; set; }
        
        public Date? StartDate { get; set; }

        public Date? EndDate { get; set; }
        
        public string? Comments { get; set; }
    }
}