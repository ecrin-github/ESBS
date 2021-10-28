namespace mdr_services.Contracts.Requests.v1
{
    public class SpecificStudyRequest : BaseQueryRequest
    {
        public int SearchType { get; set; }
        public string SearchValue { get; set; }
    }
}