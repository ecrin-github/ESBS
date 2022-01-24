using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace MdmService.Models.Object
{
    [Table("data_objects", Schema = "mdr")]
    public class DataObject
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("sd_oid")]
        public string? SdOid { get; set; }
        
        [Column("sd_sid")]
        public string? SdSid { get; set; }
        
        [Column("display_title")]
        public string? DisplayTitle { get; set; }
        
        [Column("version")]
        public string? Version { get; set; }
        
        [Column("doi")]
        public string? Doi { get; set; }
        
        [Column("doi_status_id")]
        public int? DoiStatusId { get; set; }
        
        [Column("publication_year")]
        public int? PublicationYear { get; set; }
        
        [Column("object_class_id")]
        public int? ObjectClassId { get; set; }
        
        [Column("object_type_id")]
        public int? ObjectTypeId { get; set; }
        
        [Column("managing_org_id")]
        public int? ManagingOrgId { get; set; }
        
        [Column("managing_org")]
        public string? ManagingOrg { get; set; }
        
        [Column("managing_org_ror_id")]
        public string? ManagingOrgRorId { get; set; }
        
        [Column("lang_code")]
        public string? LangCode { get; set; }
        
        [Column("access_type_id")]
        public int? AccessTypeId { get; set; }
        
        [Column("access_details")]
        public string? AccessDetails { get; set; }
        
        [Column("access_details_url")]
        public string? AccessDetailsUrl { get; set; }
        
        [Column("url_last_checked", TypeName = "Date")]
        public DateTime? UrlLastChecked { get; set; } 
        
        [Column("eosc_category")]
        public int? EoscCategory { get; set; }
        
        [Column("add_study_contribs")]
        public bool? AddStudyContribs { get; set; }
        
        [Column("add_study_topics")]
        public bool? AddStudyTopics { get; set; }
        
        [Column("created_on")]
        public DateTime? CreatedOn { get; set; }

        [Column("last_edited_by")]
        public string? LastEditedBy {get; set;}
    }
}