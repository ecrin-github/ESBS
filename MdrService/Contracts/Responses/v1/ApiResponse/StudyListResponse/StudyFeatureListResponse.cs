namespace MdrService.Contracts.Responses.v1.ApiResponse.StudyListResponse
{
    #nullable enable
    public class StudyFeatureListResponse
    {
        public int? Id { get; set; }
        
        public string? FeatureType { get; set; }
        
        public string? FeatureValue { get; set; }
    }
}