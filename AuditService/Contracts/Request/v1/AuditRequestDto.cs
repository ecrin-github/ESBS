namespace AuditService.Contracts.Request.v1;

public class AuditRequestDto
{
    public string? TableName {get; set;}

    public int? TableId {get; set;}

    public int? ChangeType {get; set;}
    
    public string? Prior {get; set;}

    public string? Post {get; set;}
}