using System;

#nullable enable
namespace mdm_services.DTO.Object
{
    public class ObjectInstanceDto
    {
        public int? Id { get; set; }
        
        public string? SdOid { get; set; }
        
        public int? InstanceTypeId { get; set; }
        
        public int? RepositoryOrgId { get; set; }
        
        public string? RepositoryOrg { get; set; }
        
        public string? Url { get; set; }
        
        public bool? UrlAccessible { get; set; }
        
        public DateTime? UrlLastChecked { get; set; }
        
        public int? ResourceTypeId { get; set; }
        
        public string? ResourceSize { get; set; }
        
        public string? ResourceSizeUnits { get; set; }
        
        public string? ResourceComments { get; set; }
        
        public DateTime? CreatedOn { get; set; }
    }
}