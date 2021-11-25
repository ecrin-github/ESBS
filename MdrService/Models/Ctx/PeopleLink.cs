using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace MdrService.Models.Ctx
{
    [Table("people_links", Schema = "ctx")]
    public class PeopleLink
    {
        [Key]
        public int Id { get; set; }

        [Column("person_id")]
        public int PersonId { get; set; }
        
        [Column("link_type")]
        public int LinkType { get; set; }
        
        [Column("link_value")]
        public string? LinkValue { get; set; }
        
        [Column("notes")]
        public string? Notes { get; set; }
        
        [Column("source")]
        public string? Source { get; set; }
        
        [Column("link_date_added", TypeName = "Date")]
        public DateTime? LinkDateAdded { get; set; }
    }
}