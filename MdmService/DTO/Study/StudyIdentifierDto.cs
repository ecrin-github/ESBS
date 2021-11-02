using System;

#nullable enable
namespace MdmService.DTO.Study
{
    public class StudyIdentifierDto
    {
        public int? Id { get; set; }
        
        public string? SdSid { get; set; }
        
        public string? IdentifierValue { get; set; }
        
        public int? IdentifierTypeId { get; set; }
        
        public int? IdentifierOrgId { get; set; }
        
        public string? IdentifierOrg { get; set; }

        public string? IdentifierOrgRorId { get; set; }
        
        public string? IdentifierDate { get; set; }
        
        public string? IdentifierLink { get; set; }
        
        public DateTime? CreatedOn { get; set; }
    }
}