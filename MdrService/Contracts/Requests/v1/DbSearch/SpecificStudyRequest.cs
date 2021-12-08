namespace MdrService.Contracts.Requests.v1.DbSearch
{
    public class SpecificStudyRequest : BaseQueryRequest
    {
        public int SearchType { get; set; }
        public string SearchValue { get; set; }
    }
}