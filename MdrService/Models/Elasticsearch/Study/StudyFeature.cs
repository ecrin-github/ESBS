using Nest;

namespace MdrService.Models.Elasticsearch.Study
{
    public class StudyFeature
    {
        [Number(Name = "id")]
        public int? Id { get; set; }
        
        [Object]
        [PropertyName("feature_type")]
        #nullable enable
        public FeatureType? FeatureType { get; set; }
        
        [Object]
        [PropertyName("feature_value")]
        #nullable enable
        public FeatureValue? FeatureValue { get; set; }
    }
}