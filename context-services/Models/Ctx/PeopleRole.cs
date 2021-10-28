using System;
using LinqToDB.Mapping;

namespace context_services.Models.Ctx
{
    [Table("people_role", Schema = "ctx")]
    public class PeopleRole
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }
        
        [Column("person_id")]
        public int PersonId { get; set; }
        
        [Column("role_id")]
        public int RoleId { get; set; }
        
        [Column("org_id")]
        public int OrgId { get; set; }
        
        [Column("designation")]
        public string Designation { get; set; }
        
        [Column("is_current")]
        public bool IsCurrent { get; set; }
        
        [Column("notes")]
        public string Notes { get; set; }
        
        [Column("created_on")]
        public DateTime CreatedOn { get; set; }
    }
}