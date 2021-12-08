using Nest;

#nullable enable
namespace MdrService.Models.Elasticsearch.Object
{
    public class DatasetDeidentLevel
    {
        [Number(Name = "deident_type_id")]
        public int? DeidentTypeId { get; set; }
        
        [Text(Name = "deident_type")]
        public string? DeidentType { get; set; }
        
        [Boolean(Name = "deident_direct")]
        public bool? DeidentDirect { get; set; }
        
        [Boolean(Name = "deident_hipaa")]
        public bool? DeidentHipaa { get; set; }
        
        [Boolean(Name = "deident_dates")]
        public bool? DeidentDates { get; set; }
        
        [Boolean(Name = "deident_nonarr")]
        public bool? DeidentNonarr { get; set; }
        
        [Boolean(Name = "deident_kanon")]
        public bool? DeidentKanon { get; set; }
        
        [Text(Name = "deident_details")]
        public string? DeidentDetails { get; set; }
    }
}