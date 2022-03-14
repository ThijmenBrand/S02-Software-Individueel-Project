using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class Asset
    {
        [Key]
        public int FileId { get; set; }
        public string FileName { get; set; }
        public string FileContentType { get; set; }
        public byte[] FileData { get; set; }
        public int ProjectId { get; set; }
        public virtual Project? Project { get; set; }
    }
}
