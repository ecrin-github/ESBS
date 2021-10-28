using Nest;

namespace mdr_services.Models.Elasticsearch.Object
{
    public class DatasetRecordKeys
    {
        [Number(Name = "keys_type_id")]
        #nullable enable
        public int? KeysTypeId { get; set; }
        
        [Text(Name = "keys_type")]
        #nullable enable
        public string? KeysType { get; set; }
        
        [Text(Name = "keys_details")]
        #nullable enable
        public string? KeysDetails { get; set; }
    }
}