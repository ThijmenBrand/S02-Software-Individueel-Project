using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidatorMiddleware
{
    public interface IInputMiddleWare
    {
        bool ValidateNull<T>(T input);
        bool ValidateZero(int input);
        bool ProjectParameterValidator(Project input);
    }
}
