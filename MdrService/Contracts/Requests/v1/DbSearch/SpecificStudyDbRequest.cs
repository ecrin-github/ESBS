namespace MdrService.Contracts.Requests.v1.DbSearch
{
    public class SpecificStudyDbRequest : BaseQueryDbRequest
    {
        public int SearchType { get; set; }
        public string SearchValue { get; set; }
    }
}