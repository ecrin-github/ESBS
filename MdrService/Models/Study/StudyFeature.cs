using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace MdrService.Models.Study
{
    [Table("study_features", Schema = "core")]
    public class StudyFeature
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("study_id")]
        public int StudyId { get; set; }
        
        [Column("feature_type_id")]
        public int? FeatureTypeId { get; set; }

        [Column("feature_value_id")]
        public int? FeatureValueId { get; set; }
    }
}