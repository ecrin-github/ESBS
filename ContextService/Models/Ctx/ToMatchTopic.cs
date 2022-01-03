using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace ContextService.Models.Ctx
{
    [Table("to_match_topics", Schema = "ctx")]
    public class ToMatchTopic
    {
        [Column("source_id")]
        public int? SourceId {get; set;}

        [Column("topic_value")]
        public string? TopicValue {get; set;}

        [Column("number_of")]
        public int? NumberOf {get; set;}
    }
}