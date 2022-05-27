namespace Helpers;

public class AppSettings
{
    public string Secret { get; set; } = String.Empty;
    public string Issuer { get; set; } = String.Empty;
    public string Audience { get; set; } = String.Empty;
    public string Subject { get; set; } = String.Empty;
}