using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class Tasks
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        [MaxLength(100)]
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string TaskTag { get; set; }
        public DateTime TaskStartTime { get; set; }
        public DateTime TaskEndTime { get; set; }
        public int TaskImportance { get; set; }
        public int TaskWorkLoad { get; set; }
        public Time? TaskTime { get; set; } = null!;
        public int SprintId { get; set; }
        [NotMapped]
        public virtual Sprint? Sprint { get; set; }
    }
}
