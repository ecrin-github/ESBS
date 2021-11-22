using MdrService.Contracts.Responses.v1.Common;

namespace MdrService.Contracts.Responses.v1.ObjectListResponse
{
    #nullable enable
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