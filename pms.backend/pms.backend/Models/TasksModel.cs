using System.ComponentModel.DataAnnotations;

namespace pms.backend.Models
{
    public class TasksModel
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        public string TaskName { get; set; }
        public string TaskDiscription { get; set; }
        public string TaskTag { get; set; }
        public DateTime TaskStartTime { get; set; }
        public DateTime TaskEndTime { get; set; }

        [Required]
        public ProjectsModel Project { get; set; }
    }
}
