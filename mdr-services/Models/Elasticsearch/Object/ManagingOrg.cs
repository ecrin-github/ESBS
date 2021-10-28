using Nest;

namespace mdr_services.Models.Elasticsearch.Object
{
    public class ManagingOrg
    {
        [Number(Name = "id")]
        #nullable enable
        public int? Id { get; set; }
        
        [Text(Name = "name")]
        #nullable enable
        public string? Name { get; set; }
        
        [Text(Name = "ror_id")]
        #nullable enable
        public string? RorId { get; set; }
    }
}