using System.Collections.Generic;
using MdrService.Contracts.Responses.v1.Common;
using MdrService.Contracts.Responses.v1.ObjectListResponse;

#nullable enable
namespace MdrService.Contracts.Responses.v1.SearchServiceResponse
{
    public class SearchDataObjectListResponse
    {
        public int? Id { get; set; }
        
        public string? Doi { get; set; }
        
        public string? DisplayTitle { get; set; }
        
        public string? ObjectClass { get; set; }
        
        public string? ObjectType { get; set; }
        
        public string? ObjectUrl { get; set; }
        
        public int? PublicationYear { get; set; }
        
        public string? LangCode { get; set; }
        
        public string? AccessType { get; set; }
        
        public int? EoscCategory { get; set; } 
        
        public ICollection<ObjectInstanceListResponse>? ObjectInstances { get; set; }

        public string? ProvenanceString { get; set; }
    }
}