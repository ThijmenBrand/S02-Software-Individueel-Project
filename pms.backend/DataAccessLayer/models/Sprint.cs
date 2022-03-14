using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class Sprint
    {
        [Key]
        public int SprintId { get; set; }
        public int SprintDuration { get; set; }
        public DateTime SprintStart { get; set; }
        public int ProjectId { get; set; }
        public virtual Project? Project { get; set; }
        public virtual ICollection<Tasks>? Tasks { get; set; }
    }
}
