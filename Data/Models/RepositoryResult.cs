namespace Data.Models;

public class RepositoryResult
{
    public bool Success { get; set; }
    public int StatusCode { get; set; }
    public string? Error { get; set; }
}
public class RepositoryResult<T> : RepositoryResult where T : class
{
    public T? Result { get; set; }
}