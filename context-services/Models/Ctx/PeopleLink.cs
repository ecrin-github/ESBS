using System;
using LinqToDB;
using LinqToDB.Mapping;

namespace context_services.Models.Ctx
{
    [Table("people_links", Schema = "ctx")]
    public class PeopleLink
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }

        [Column("person_id")]
        public int PersonId { get; set; }
        
        [Column("link_type")]
        public int LinkType { get; set; }
        
        [Column("link_value")]
        public string LinkValue { get; set; }
        
        [Column("notes")]
        public string Notes { get; set; }
        
        [Column("source")]
        public string Source { get; set; }
        
        [Column("link_date_added", DataType = DataType.Date)]
        public DateTime LinkDateAdded { get; set; }
    }
}