namespace MdrService.Contracts.Responses.v1
{
    public class SearchResponse : BaseResponse
    {
        public int? Page { get; set; }
        public int? Size { get; set; }
    }
}