using Nest;

#nullable enable
namespace MdrService.Models.Elasticsearch.Object
{
    public class ObjectContributor
    {
        [Number(Name = "id")]
        public int? Id { get; set; }
        
        [Object]
        [PropertyName("contribution_type")]
        public ContributionType? ContributionType { get; set; }
        
        [Boolean(Name = "is_individual")]
        public bool? IsIndividual { get; set; }
        
        [Object]
        [PropertyName("organisation")]
        public ContribOrg? Organisation { get; set; }
        
        [Object]
        [PropertyName("person")]
        public Person? Person { get; set; }
    }
}