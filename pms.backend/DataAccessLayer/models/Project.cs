using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class Project
    {
        [Key]
        [Required]
        public int ProjectId { get; set; }
        [Required]
        [MaxLength(50)]
        public string ProjectName { get; set; } = string.Empty;
        [MaxLength(150)]
        public string ProjectDescription { get; set; } = string.Empty;
        public int ProjectOwnerId { get; set; }
        public DateTime ProjectDate { get; set; }
        [NotMapped]
        public virtual ICollection<Sprint>? Sprints { get; set; }
        [NotMapped]

        public virtual ICollection<Link>? Links { get; set; }
        [NotMapped]

        public virtual ICollection<Asset>? Assets { get; set; }

        public Project(string projectName, string projectDescription)
        {
            ProjectName = projectName;
            ProjectDescription = projectDescription;
        }
    }
}
