using System.ComponentModel.DataAnnotations;

namespace pms.backend.Models.Projects
{
    public class ProjectsModel : IProjectsModel
    {
        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectOwnerId { get; set; }
        public DateTime ProjectDate { get; set; }
    }
}
