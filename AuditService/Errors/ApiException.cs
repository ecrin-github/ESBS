namespace AuditService.Errors
{
    public class ApiException
    {
        private int StatusCode { get; set; }
        private string Message { get; set; }
        private string Details { get; set; }

        public ApiException(int statusCode, string? message = null, string? details = null)
        {
            StatusCode = statusCode;
            Message = message ?? string.Empty;
            Details = details ?? string.Empty;
        }
    }
}