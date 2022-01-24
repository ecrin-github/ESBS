using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace MdmService.Models.Study
{
    [Table("studies", Schema = "mdr")]
    public class Study
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("sd_sid")]
        public string? SdSid { get; set; }
        
        [Column("mdr_sd_sid")]
        public string? MdrSdSid { get; set; }
        
        [Column("mdr_source_id")]
        public int? MdrSourceId { get; set; }
        
        [Column("display_title")]
        public string? DisplayTitle { get; set; }
        
        [Column("title_lang_code")]
        public string? TitleLangCode { get; set; }
        
        [Column("brief_description")]
        public string? BriefDescription { get; set; }
        
        [Column("data_sharing_statement")]
        public string? DataSharingStatement { get; set; }
        
        [Column("study_start_year")]
        public int? StudyStartYear { get; set; }
        
        [Column("study_start_month")]
        public int? StudyStartMonth { get; set; }
        
        [Column("study_type_id")]
        public int? StudyTypeId { get; set; }
        
        [Column("study_status_id")]
        public int? StudyStatusId { get; set; }
        
        [Column("study_enrolment")]
        public int? StudyEnrolment { get; set; }
        
        [Column("study_gender_elig_id")]
        public int? StudyGenderEligId { get; set; }
        
        [Column("min_age")]
        public int? MinAge { get; set; }
        
        [Column("min_age_units_id")]
        public int? MinAgeUnitsId { get; set; }
        
        [Column("max_age")]
        public int? MaxAge { get; set; }
        
        [Column("max_age_units_id")]
        public int? MaxAgeUnitsId { get; set; }
        
        [Column("created_on")]
        public DateTime? CreatedOn { get; set; }

        [Column("last_edited_by")]
        public string? LastEditedBy {get; set;}
    }
}