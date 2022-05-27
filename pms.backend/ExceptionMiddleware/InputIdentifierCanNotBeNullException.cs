namespace ExceptionMiddleware;

public class InputIdentifierCanNotBeNullException : Exception
{
    public InputIdentifierCanNotBeNullException() { }
    public InputIdentifierCanNotBeNullException(string message) : base(message){ }
    public InputIdentifierCanNotBeNullException(string message, Exception innerException) : base(message, innerException) { }
}