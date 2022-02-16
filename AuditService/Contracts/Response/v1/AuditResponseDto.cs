namespace AuditService.Contracts.Response.v1;

#nullable enable
public class AuditResponseDto
{
    public int Id {get; set;}

    public string? TableName {get; set;}

    public int? TableId {get; set;}

    public int? ChangeType {get; set;}

    public DateTime ChangeTime {get; set;}

    public string? UserName {get; set;}

    public string? Prior {get; set;}

    public string? Post {get; set;}
}