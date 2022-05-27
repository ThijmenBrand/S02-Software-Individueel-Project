using DataAccessLayer.Models;
using ExceptionMiddleware;

namespace ValidatorMiddleware
{
    public class InputMiddleWare : IInputMiddleWare
    {
        public bool ValidateNull<T>(T input)
        {
            if (input == null)
                throw new InputIdentifierCanNotBeNullException("input can not be null!");
            return true;
        }
        public bool ValidateZero(int input)
        {
            if (input <= 0)
                throw new InputIdentifierCanNotBeZeroException("input can not be zero or lower, the query will never give any results");
            return true;
        }
        public bool ProjectParameterValidator(Project input)
        {
            if (input == null)
                throw new InputIdentifierCanNotBeNullException("the given project can not be null!");

            if (String.IsNullOrEmpty(input.ProjectName))
                throw new ProjectParametersInvalidException("Project name can not be empty!");

            return true;
        }
    }
}