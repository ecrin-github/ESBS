using mdr_services.Models.Elasticsearch.Object;

#nullable enable
namespace mdr_services.Contracts.Responses.v1.ObjectListResponse
{
    public class ObjectContributorListResponse
    {
        public int? Id { get; set; }
        
        public string? ContributionType { get; set; }
        
        public bool? IsIndividual { get; set; }
        
        public ContribOrg? Organisation { get; set; }
        
        public Person? Person { get; set; }
    }
}