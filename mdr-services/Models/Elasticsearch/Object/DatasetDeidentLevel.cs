using Nest;

namespace mdr_services.Models.Elasticsearch.Object
{
    public class DatasetDeidentLevel
    {
        [Number(Name = "deident_type_id")]
        #nullable enable
        public int? DeidentTypeId { get; set; }
        
        [Text(Name = "deident_type")]
        #nullable enable
        public string? DeidentType { get; set; }
        
        [Boolean(Name = "deident_direct")]
        #nullable enable
        public bool? DeidentDirect { get; set; }
        
        [Boolean(Name = "deident_hipaa")]
        #nullable enable
        public bool? DeidentHipaa { get; set; }
        
        [Boolean(Name = "deident_dates")]
        #nullable enable
        public bool? DeidentDates { get; set; }
        
        [Boolean(Name = "deident_nonarr")]
        #nullable enable
        public bool? DeidentNonarr { get; set; }
        
        [Boolean(Name = "deident_kanon")]
        public bool? DeidentKanon { get; set; }
        
        [Text(Name = "deident_details")]
        #nullable enable
        public string? DeidentDetails { get; set; }
    }
}