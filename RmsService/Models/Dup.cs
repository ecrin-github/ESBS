using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace RmsService.Models
{
    [Table("dups", Schema = "rms")]
    public class Dup
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("org_id")]
        public int OrgId { get; set; }
        
        [Column("display_name")]
        public string? DisplayName { get; set; }
        
        [Column("status_id")]
        public int? StatusId { get; set; }
        
        [Column("initial_contact_date", TypeName = "Date")]
        public DateTime? InitialContactDate { get; set; }
        
        [Column("set_up_completed", TypeName = "Date")]
        public DateTime? SetUpCompleted { get; set; }
        
        [Column("prereqs_met", TypeName = "Date")]
        public DateTime? PrereqsMet { get; set; }
        
        [Column("dua_agreed_date", TypeName = "Date")]
        public DateTime? DuaAgreedDate { get; set; }
        
        [Column("availability_requested", TypeName = "Date")]
        public DateTime? AvailabilityRequested { get; set; }
        
        [Column("availability_confirmed", TypeName = "Date")]
        public DateTime? AvailabilityConfirmed { get; set; }
        
        [Column("access_confirmed", TypeName = "Date")]
        public DateTime? AccessConfirmed { get; set; }
        
        [Column("created_on")]
        public DateTime? CreatedOn { get; set; }
    }
}