using DataAccessLayer.Models;
using ExceptionMiddleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ardalis.GuardClauses
{
    public static class ProjectParameters
    {
        public static void ProjectParams(this IGuardClause guardClause, Project input, string parameterName)
        {
            if (String.IsNullOrEmpty(input.ProjectName))
                throw new ProjectParametersInvalidException("Project name can not be empty!");
        }
    }
}
