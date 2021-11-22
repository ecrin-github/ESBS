using MdrService.Contracts.Responses.v1.Common;

namespace MdrService.Contracts.Responses.v1.ObjectListResponse
{
    #nullable enable
    public class ObjectInstanceListResponse
    {
        public int? Id { get; set; }
        
        public string? RepositoryOrg { get; set; }
        
        public InstanceAccessDetails? AccessDetails { get; set; }
        
        public InstanceResourceDetails? ResourceDetails { get; set; }
    }
}