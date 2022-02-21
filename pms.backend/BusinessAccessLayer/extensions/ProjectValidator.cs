using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.extensions
{
    public class ProjectValidator
    {
        public bool ProjectParameterValidator(Project project)
        {
            if(project == null)
                return false;

            project.ProjectName = project.ProjectName.Trim();
            project.ProjectDescription = project.ProjectDescription.Trim();

            if(project.ProjectName.Length <= 0 || project.ProjectName == "")
                return false;

            return true;
        }
    }
}
