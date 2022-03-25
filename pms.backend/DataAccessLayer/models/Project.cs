﻿using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectOwnerId { get; set; }
        public DateTime ProjectDate { get; set; }
        public virtual ICollection<Tasks>? Tasks { get; set; }
        public virtual ICollection<Sprint>? Sprints { get; set; }
        public virtual ICollection<Link>? Links { get; set; }
        public virtual ICollection<Asset>? Assets { get; set; }
    }
}
