using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class Sprint
    {
        [Key]
        [Required]
        public int SprintId { get; set; }
        [Required]
        [MaxLength(20)]
        public string SprintName { get; set; } = string.Empty;
        [Required]
        public DateTime SprintStart { get; set; }
        [Required]
        public DateTime SprintEnd { get; set; }
        [Required]
        public int ProjectId { get; set; }
        [NotMapped]
        public virtual Project? Project { get; set; }
        [NotMapped]
        public virtual ICollection<Tasks>? Tasks { get; set; }
    }
}
