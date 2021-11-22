namespace MdrService.Contracts.Responses.v1.Common
{
    #nullable enable
    public class InstanceResourceDetails
    {
        public int? TypeId { get; set; }
        
        public string? TypeName { get; set; }
        
        public string? Size { get; set; }
        
        public string? SizeUnit { get; set; }
        
        public string? Comments { get; set; }
    }
}