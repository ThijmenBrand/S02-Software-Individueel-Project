using System.ComponentModel.DataAnnotations;

namespace pms.backend.Models
{
    public class ProjectsModel
    {
        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDiscription { get; set; }
    }
}
