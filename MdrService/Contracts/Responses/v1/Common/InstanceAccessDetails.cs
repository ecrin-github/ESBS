namespace MdrService.Contracts.Responses.v1.Common
{
    #nullable enable
    public class InstanceAccessDetails
    {
        public bool? DirectAccess { get; set; }
        
        public string? Url { get; set; }
        
        public string? UrlLastChecked { get; set; }
    }
}