using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class Tasks
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string TaskTag { get; set; }
        public DateTime TaskStartTime { get; set; }
        public DateTime TaskEndTime { get; set; }
        public Time? TaskTime { get; set; } = null!;

        public int ProjectId { get; set; }
        public virtual Project? Project { get; set; }
        public int SprintId { get; set; }
        public virtual Sprint? Sprint { get; set; }
    }
}
