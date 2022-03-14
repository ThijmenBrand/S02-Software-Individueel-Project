using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class Time
    {
        [Key]
        public int TimeRecordId { get; set; }
        public string TimeRecordName { get; set; }
        public double TimeRecordTiming { get; set; }
        public int TaskId { get; set; }
        public virtual Tasks? Task { get; set; }
    }
}
