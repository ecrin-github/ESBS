using Nest;

namespace mdr_services.Models.Elasticsearch.Object
{
    public class ObjectInstance
    {
        [Number(Name = "id")]
        #nullable enable
        public int? Id { get; set; }
        
        [Object]
        [PropertyName("repository_org")]
        #nullable enable
        public RepositoryOrg? RepositoryOrg { get; set; }
        
        [Object]
        [PropertyName("access_details")]
        #nullable enable
        public InstanceAccessDetails? AccessDetails { get; set; }
        
        [Object]
        [PropertyName("resource_details")]
        #nullable enable
        public InstanceResourceDetails? ResourceDetails { get; set; }
    }
}