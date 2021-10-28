using System;
using LinqToDB;
using LinqToDB.Mapping;

namespace context_services.Models.Lup
{
    [Table("language_codes", Schema = "lup")]
    public class LanguageCode
    {
        [Column("code")]
        public string Code { get; set; }
        
        [Column("marc_code")]
        public string MarcCode { get; set; }
        
        [Column("lang_name_en")]
        public string LangNameEn { get; set; }
        
        [Column("lang_name_fr")]
        public string LangNameFr { get; set; }
        
        [Column("lang_name_de")]
        public string LangNameDe { get; set; }
        
        [Column("source")]
        public string Source { get; set; }
        
        [Column("date_added", DataType = DataType.Date)]
        public DateTime DateAdded { get; set; }
    }
}