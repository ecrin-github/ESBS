using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContextService.Models.Lup
{
    [Table("title_types", Schema = "lup")]
    public class TitleType
    {
        [Column("id")]
        public int Id { get; set; }
        
        [Column("name")]
        public string Name { get; set; }
        
        [Column("applies_to")]
        public string AppliesTo { get; set; }
        
        [Column("description")]
        public string Description { get; set; }
        
        [Column("use_in_data_entry")]
        public bool? UseInDataEntry { get; set; }
        
        [Column("list_order")]
        public int ListOrder { get; set; }
        
        [Column("source")]
        public string Source { get; set; }
        
        [Column("date_added", TypeName = "Date")]
        public DateTime DateAdded { get; set; }
    }
}