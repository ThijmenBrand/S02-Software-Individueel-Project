using System;

namespace ExceptionMiddleware;

public class ProjectParametersInvalidException : Exception
{
    public ProjectParametersInvalidException() { }
    public ProjectParametersInvalidException(string message) : base(message) { }
    public ProjectParametersInvalidException(string message, Exception innerException) : base(message, innerException) { }
}
