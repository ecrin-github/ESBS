using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContextService.Models.Lup
{
    [Table("study_feature_categories", Schema = "lup")]
    public class StudyFeatureCategory
    {
        [Column("id")]
        public int Id { get; set; }
        
        [Column("feature_type_id")]
        public int FeatureTypeId { get; set; }
        
        [Column("name")]
        public string Name { get; set; }
        
        [Column("description")]
        public string Description { get; set; }
        
        [Column("list_order")]
        public int ListOrder { get; set; }
        
        [Column("source")]
        public string Source { get; set; }
        
        [Column("date_added", TypeName = "Date")]
        public DateTime DateAdded { get; set; }
    }
}