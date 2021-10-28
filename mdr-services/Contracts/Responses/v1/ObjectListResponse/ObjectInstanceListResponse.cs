using mdr_services.Models.Elasticsearch.Object;

#nullable enable
namespace mdr_services.Contracts.Responses.v1.ObjectListResponse
{
    public class ObjectInstanceListResponse
    {
        public int? Id { get; set; }
        
        public string? RepositoryOrg { get; set; }
        
        public InstanceAccessDetails? AccessDetails { get; set; }
        
        public InstanceResourceDetails? ResourceDetails { get; set; }
    }
}