using Nest;

#nullable enable
namespace MdrService.Models.Elasticsearch.Study
{
    public class StudyFeature
    {
        [Number(Name = "id")]
        public int? Id { get; set; }
        
        [Object]
        [PropertyName("feature_type")]
        public FeatureType? FeatureType { get; set; }
        
        [Object]
        [PropertyName("feature_value")]
        public FeatureValue? FeatureValue { get; set; }
    }
}