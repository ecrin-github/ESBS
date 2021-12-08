using Nest;

#nullable enable
namespace MdrService.Models.Elasticsearch.Object
{
    public class ObjectInstance
    {
        [Number(Name = "id")]
        public int? Id { get; set; }
        
        [Object]
        [PropertyName("repository_org")]
        public RepositoryOrg? RepositoryOrg { get; set; }
        
        [Object]
        [PropertyName("access_details")]
        public InstanceAccessDetails? AccessDetails { get; set; }
        
        [Object]
        [PropertyName("resource_details")]
        public InstanceResourceDetails? ResourceDetails { get; set; }
    }
}