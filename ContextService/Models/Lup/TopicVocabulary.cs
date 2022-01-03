using System;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace ContextService.Models.Lup
{
    [Table("topic_vocabularies", Schema = "lup")]
    public class TopicVocabulary
    {
        [Column("id")]
        public int Id {get; set;}

        [Column("name")]
        public string? Name {get; set;}

        [Column("description")]
        public string? Description {get; set;}

        [Column("url")]
        public string? Url {get; set;}

        [Column("list_order")]
        public int? ListOrder {get; set;}

        [Column("date_added")]
        public DateTime? DateAdded {get; set;}
    }
}