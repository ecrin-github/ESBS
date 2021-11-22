using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace MdrService.Models.Object
{
    [Table("object_dates", Schema = "core")]
    public class ObjectDate
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("object_id")]
        public int ObjectId { get; set; }
        
        [Column("date_type_id")]
        public int? DateTypeId { get; set; }
        
        [Column("date_is_range")]
        public bool? DateIsRange { get; set; }
        
        [Column("date_as_string")]
        public string? DateAsString { get; set; }
        
        [Column("start_year")]
        public int? StartYear { get; set; }
        
        [Column("start_month")]
        public int? StartMonth { get; set; }
        
        [Column("start_day")]
        public int? StartDay { get; set; }
        
        [Column("end_year")]
        public int? EndYear { get; set; }
        
        [Column("end_month")]
        public int? EndMonth { get; set; }
        
        [Column("end_day")]
        public int? EndDay { get; set; }
        
        [Column("details")]
        public string? Details { get; set; }
    }
}