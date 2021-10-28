using System;

#nullable enable
namespace mdm_services.DTO.Study
{
    public class StudyFeatureDto
    {
        public int? Id { get; set; }
        
        public string? SdSid { get; set; }
        
        public int? FeatureTypeId { get; set; }

        public int? FeatureValueId { get; set; }
        
        public DateTime? CreatedOn { get; set; }
    }
}