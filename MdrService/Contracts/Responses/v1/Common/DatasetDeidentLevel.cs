namespace MdrService.Contracts.Responses.v1.Common
{
    #nullable enable
    public class DatasetDeidentLevel
    {
        public int? DeidentTypeId { get; set; }
        
        public string? DeidentType { get; set; }
        
        public bool? DeidentDirect { get; set; }
        
        public bool? DeidentHipaa { get; set; }
        
        public bool? DeidentDates { get; set; }
        
        public bool? DeidentNonarr { get; set; }
        
        public bool? DeidentKanon { get; set; }
        
        public string? DeidentDetails { get; set; }
    }
}