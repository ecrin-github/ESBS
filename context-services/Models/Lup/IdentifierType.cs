using System;
using LinqToDB;
using LinqToDB.Mapping;

namespace context_services.Models.Lup
{
    [Table("identifier_types", Schema = "lup")]
    public class IdentifierType
    {
        [Column("id")]
        public int Id { get; set; }
        
        [Column("name")]
        public string Name { get; set; }
        
        [Column("description")]
        public string Description { get; set; }
        
        [Column("applies_to")]
        public string AppliesTo { get; set; }
        
        [Column("list_order")]
        public int ListOrder { get; set; }
        
        [Column("source")]
        public string Source { get; set; }
        
        [Column("date_added", DataType = DataType.Date)]
        public DateTime DateAdded { get; set; }
    }
}