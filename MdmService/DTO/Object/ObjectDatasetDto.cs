using System;

#nullable enable
namespace MdmService.DTO.Object
{
    public class ObjectDatasetDto
    {
        public int? Id { get; set; }
        
        public string? SdOid { get; set; }
        
        public int? RecordKeysTypeId { get; set; }
        
        public string? RecordKeysDetails { get; set; }
        
        public int? DeidentTypeId { get; set; }
        
        public bool? DeidentDirect { get; set; }
        
        public bool? DeidentHipaa { get; set; }
        
        public bool? DeidentDates { get; set; }
        
        public bool? DeidentNonarr { get; set; }
        
        public bool? DeidentKanon { get; set; }
        
        public string? DeidentDetails { get; set; }
        
        public int? ConsentTypeId { get; set; }
        
        public bool? ConsentNoncommercial { get; set; }
        
        public bool? ConsentGeogRestrict { get; set; }
        
        public bool? ConsentResearchType { get; set; }
        
        public bool? ConsentGeneticOnly { get; set; }
        
        public bool? ConsentNoMethods { get; set; }
        
        public string? ConsentDetails { get; set; }
        
        public DateTime? CreatedOn { get; set; }
    }
}