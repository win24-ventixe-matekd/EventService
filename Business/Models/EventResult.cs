namespace Business.Models;

public class EventResult
{
    public bool Success { get; set; }
    public int StatusCode { get; set; }
    public string? Error { get; set; }
}

public class EventResult<T> : EventResult where T : class
{
    public T? Result { get; set; }
}