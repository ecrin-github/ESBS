#nullable enable
namespace MdrService.Contracts.Responses.v1.ObjectListResponse
{
    public class ObjectRightListResponse
    {
        public int? Id { get; set; }
        
        public string? RightsName { get; set; }
        
        public string? RightsUrl { get; set; }
        
        public string? Comments { get; set; }
    }
}