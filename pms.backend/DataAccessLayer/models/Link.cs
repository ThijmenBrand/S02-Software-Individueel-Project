using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class Link
    {
        [Key]
        public int LinkId { get; set; }
        public string LinkName { get; set; }
        public string LinkUrl { get; set; }
        public int ProjectId { get; set; }
        public virtual Project? Project { get; set; }
    }
}
