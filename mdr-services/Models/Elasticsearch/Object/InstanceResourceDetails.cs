using Nest;

namespace mdr_services.Models.Elasticsearch.Object
{
    public class InstanceResourceDetails
    {
        [Number(Name = "type_id")]
        #nullable enable
        public int? TypeId { get; set; }
        
        [Text(Name = "type_name")]
        #nullable enable
        public string? TypeName { get; set; }
        
        [Number(Name = "size")]
        #nullable enable
        public float? Size { get; set; }
        
        [Text(Name = "size_unit")]
        #nullable enable
        public string? SizeUnit { get; set; }
        
        [Text(Name = "comments")]
        #nullable enable
        public string? Comments { get; set; }
    }
}