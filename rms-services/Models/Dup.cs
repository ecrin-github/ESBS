using System;
using LinqToDB;
using LinqToDB.Mapping;

#nullable enable
namespace rms_services.Models
{
    [Table("dups", Schema = "rms")]
    public class Dup
    {
        [PrimaryKey, Identity]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("org_id")]
        public int OrgId { get; set; }
        
        [Column("display_name")]
        public string? DisplayName { get; set; }
        
        [Column("status_id")]
        public int? StatusId { get; set; }
        
        [Column("initial_contact_date", DataType = DataType.Date)]
        public DateTime? InitialContactDate { get; set; }
        
        [Column("set_up_completed", DataType = DataType.Date)]
        public DateTime? SetUpCompleted { get; set; }
        
        [Column("prereqs_met", DataType = DataType.Date)]
        public DateTime? PrereqsMet { get; set; }
        
        [Column("dua_agreed_date", DataType = DataType.Date)]
        public DateTime? DuaAgreedDate { get; set; }
        
        [Column("availability_requested", DataType = DataType.Date)]
        public DateTime? AvailabilityRequested { get; set; }
        
        [Column("availability_confirmed", DataType = DataType.Date)]
        public DateTime? AvailabilityConfirmed { get; set; }
        
        [Column("access_confirmed", DataType = DataType.Date)]
        public DateTime? AccessConfirmed { get; set; }
        
        [Column("created_on")]
        public DateTime? CreatedOn { get; set; }
    }
}