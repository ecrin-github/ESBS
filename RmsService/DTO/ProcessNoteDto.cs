using System;

#nullable enable
namespace RmsService.DTO
{
    public class ProcessNoteDto
    {
        public int Id { get; set; }
        
        public int? ProcessType { get; set; }
        
        public int? ProcessId { get; set; }
        
        public string? Text { get; set; }
        
        public int? Author { get; set; }
        
        public DateTime? CreatedOn { get; set; }
    }
}