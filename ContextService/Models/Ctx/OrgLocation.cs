using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace ContextService.Models.Ctx
{
    [Table("org_locations", Schema = "ctx")]
    public class OrgLocation
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("org_id")]
        public int OrgId { get; set; }
        
        [Column("default_name")]
        public string? DefaultName { get; set; }
        
        [Column("city_id")]
        public int CityId { get; set; }
        
        [Column("city")]
        public string? City { get; set; }
        
        [Column("country_id")]
        public int CountryId { get; set; }
        
        [Column("country")]
        public string? Country { get; set; }
        
        [Column("latitude")]
        public double Latitude { get; set; }
        
        [Column("longitude")]
        public double Longitude { get; set; }
        
        [Column("created_on")]
        public DateTime? CreatedOn { get; set; }
    }
}