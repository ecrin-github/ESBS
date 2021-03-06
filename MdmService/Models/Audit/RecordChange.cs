using System;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace MdmService.Models.Audit
{
    [Table("record_changes", Schema = "mdr")]
    public class RecordChange
    {
        [Column("id")]
        public int Id {get; set;}

        [Column("table_name")]
        public string? TableName {get; set;}

        [Column("table_id")]
        public int? TableId {get; set;}

        [Column("change_type")]
        public int? ChangeType {get; set;}

        [Column("change_time")]
        public DateTime ChangeTime {get; set;}

        [Column("user_name")]
        public string? UserName {get; set;}

        [Column("prior", TypeName = "jsonb")]
        public string? Prior {get; set;}

        [Column("post", TypeName = "jsonb")]
        public string? Post {get; set;}
    }
}