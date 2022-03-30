using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.helperClasses
{
    public interface RawSprintData
    {
        public int projectId { get; set; }
        public DateTime sprintStart { get; set; }
        public DateTime sprintEnd { get; set; }
    }
}
