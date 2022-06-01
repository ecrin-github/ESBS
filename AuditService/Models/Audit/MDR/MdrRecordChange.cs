using System.ComponentModel.DataAnnotations.Schema;

namespace AuditService.Models.Audit.MDR;

[Table("record_changes", Schema = "mdr")]
public class MdrRecordChange
{
    [Column("id")]
    public int Id { get; set; }

    [Column("table_name")]
    public string? TableName { get; set; } = string.Empty;

    [Column("table_id")]
    public int? TableId { get; set; } = 0;

    [Column("change_type")]
    public int? ChangeType { get; set; } = 0;

    [Column("change_time")]
    public DateTime ChangeTime { get; set; } = DateTime.Now;

    [Column("user_name")]
    public string? UserName { get; set; } = string.Empty;

    [Column("prior", TypeName = "jsonb")]
    public string? Prior { get; set; } = string.Empty;

    [Column("post", TypeName = "jsonb")]
    public string? Post { get; set; } = string.Empty;
}