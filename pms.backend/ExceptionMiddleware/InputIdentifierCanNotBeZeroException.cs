namespace ExceptionMiddleware;

public class InputIdentifierCanNotBeZeroException : Exception
{
    public InputIdentifierCanNotBeZeroException() { }
    public InputIdentifierCanNotBeZeroException(string message) : base(message) { }
    public InputIdentifierCanNotBeZeroException(string message, Exception innerException) : base(message, innerException) { }
}