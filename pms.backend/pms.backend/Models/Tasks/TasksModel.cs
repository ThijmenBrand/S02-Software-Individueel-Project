using System.ComponentModel.DataAnnotations;
using pms.backend.Models.Projects;

namespace pms.backend.Models.Tasks
{
    public class TasksModel : ITasksModel
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string TaskTag { get; set; }
        public DateTime TaskStartTime { get; set; }
        public DateTime TaskEndTime { get; set; }

        [Required]
        public ProjectsModel Project { get; set; }
    }
}
