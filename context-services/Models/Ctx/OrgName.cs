using LinqToDB.Mapping;

namespace context_services.Models.Ctx
{
    [Table("org_names", Schema = "ctx")]
    public class OrgName
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }
        
        [Column("org_id")]
        public int OrgId { get; set; }
        
        [Column("qualifier_id")]
        public int QualifierId { get; set; }
        
        [Column("lang_code")]
        public string LangCode { get; set; }
        
        [Column("script_code")]
        public string ScriptCode { get; set; }
        
        [Column("name")]
        public string Name { get; set; }
    }
}