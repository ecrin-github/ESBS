#nullable enable
namespace MdmService.DTO.Audit
{
    public class AuditDto
    {
        public string? TableName {get; set;}
        public int? TableId {get; set;}
        public int? ChangeType {get; set;}
        public string? UserName {get; set;}
        public string? Prior {get; set;}
        public string? Post {get; set;}
    }
}