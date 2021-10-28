using System;

#nullable enable
namespace mdm_services.DTO.Object
{
    public class ObjectRelationshipDto
    {
        public int? Id { get; set; }
        
        public string? SdOid { get; set; }
        
        public int? RelationshipTypeId { get; set; }
        
        public string? TargetSdOid { get; set; }
        
        public DateTime? CreatedOn { get; set; }
    }
}