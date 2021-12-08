using Nest;

#nullable enable
namespace MdrService.Models.Elasticsearch.Object
{
    public class InstanceResourceDetails
    {
        [Number(Name = "type_id")]
        public int? TypeId { get; set; }
        
        [Text(Name = "type_name")]
        public string? TypeName { get; set; }
        
        [Number(Name = "size")]
        public float? Size { get; set; }
        
        [Text(Name = "size_unit")]
        public string? SizeUnit { get; set; }
        
        [Text(Name = "comments")]
        public string? Comments { get; set; }
    }
}