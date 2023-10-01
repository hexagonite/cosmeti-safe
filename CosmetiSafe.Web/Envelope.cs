using CosmetiSafe.Domain;

namespace CosmetiSafe.Web;

public class Envelope
{
    public object? Result { get; set; }
    public string? ErrorCode { get; set; }
    public string? ErrorMessage { get; set; }
    public string? InvalidField { get; set; }
    public DateTime TimeGenerated { get; set; }

    private Envelope(object? result, Error? error, string? invalidField)
    {
        Result = result;
        ErrorCode = error?.Code;
        ErrorMessage = error?.Message;
        InvalidField = invalidField;
        TimeGenerated = DateTime.UtcNow;
    }
    
    public static Envelope Ok(object? result = null)
    {
        return new Envelope(result, null, null);
    }

    public static Envelope Error(Error error, string? invalidField)
    {
        return new Envelope(null, error, invalidField);
    }
}