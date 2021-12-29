namespace RmsService.Contracts.Requests.Filtering
{
    public class FilteringByTitleRequest : PaginationRequest
    {
        public string Title { get; set; }
    }
}