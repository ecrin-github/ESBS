using System;

#nullable enable
namespace mdm_services.DTO.Object
{
    public class ObjectIdentifierDto
    {
        public int? Id { get; set; }
        
        public string? SdOid { get; set; }
        
        public string? IdentifierValue { get; set; }
        
        public int? IdentifierTypeId { get; set; }
        
        public int? IdentifierOrgId { get; set; }
        
        public string? IdentifierOrg { get; set; }

        public string? IdentifierOrgRorId { get; set; }
        
        public string? IdentifierDate { get; set; }
        
        public DateTime? CreatedOn { get; set; }
    }
}