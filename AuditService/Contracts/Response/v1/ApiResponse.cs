namespace AuditService.Contracts.Response.v1;

public class ApiResponse<T>
{
    public int Total { get; set; }
    public int? Size { get; set; } = 10;
    public int? Page { get; set; } = 1;
    public int StatusCode { get; set; }
    public IList<string> Messages { get; set; } = new List<string> {};
    public ICollection<T> Data { get; set; } = new List<T> {};
}