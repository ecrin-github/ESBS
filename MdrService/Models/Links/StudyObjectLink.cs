using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MdrService.Models.Links
{
    [Table("study_object_links", Schema = "core")]
    public class StudyObjectLink
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("study_id")]
        public int StudyId { get; set; }
        
        [Column("object_id")]
        public int ObjectId { get; set; }
    }
}