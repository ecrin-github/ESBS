using Nest;

namespace MdrService.Models.Elasticsearch.Object
{
    public class ObjectContributor
    {
        [Number(Name = "id")]
        #nullable enable
        public int? Id { get; set; }
        
        [Object]
        [PropertyName("contribution_type")]
        #nullable enable
        public ContributionType? ContributionType { get; set; }
        
        [Boolean(Name = "is_individual")]
        #nullable enable
        public bool? IsIndividual { get; set; }
        
        [Object]
        [PropertyName("organisation")]
        #nullable enable
        public ContribOrg? Organisation { get; set; }
        
        [Object]
        [PropertyName("person")]
        #nullable enable
        public Person? Person { get; set; }
    }
}