namespace StockTracker.Domain.Commands.Interfaces;

public class GenericQueryResult
{
    public GenericQueryResult(bool success, string message, object data)
    {
        Success = success;
        Message = message;
        Data = data;
    }
    public bool Success { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }
}