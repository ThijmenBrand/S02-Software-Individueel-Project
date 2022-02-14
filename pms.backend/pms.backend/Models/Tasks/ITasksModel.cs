namespace pms.backend.Models.Tasks
{
    public class ITasksModel
    {
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string TaskTag { get; set; }
        public DateTime TaskStartTime { get; set; }
        public DateTime TaskEndTime { get; set; }

    }
}
