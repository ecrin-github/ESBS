using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace ContextService.Models.Ctx
{
    [Table("people", Schema = "ctx")]
    public class People
    {
        [Key]
        public int Id { get; set; }
        
        [Column("prof_title")]
        public string? ProfTitle { get; set; }
        
        [Column("prof_given_name")]
        public string? ProfGivenName { get; set; }
        
        [Column("prefix_to_key")]
        public string? PrefixToKey { get; set; }
        
        [Column("key_family_name")]
        public string? KeyFamilyName { get; set; }
        
        [Column("names_after_key")]
        public string? NamesAfterKey { get; set; }
        
        [Column("suffixes_to_key")]
        public string? SuffixesToKey { get; set; }
        
        [Column("key_name_first")]
        public int KeyNameFirst { get; set; }
        
        [Column("name_string")]
        public string? NameString { get; set; }
        
        [Column("inverted_name_string")]
        public string? InvertedNameString { get; set; }
        
        [Column("name_notes")]
        public string? NameNotes { get; set; }
        
        [Column("orcid")]
        public string? Orcid { get; set; }
    }
}