namespace Business.Models;

public class Event
{
    public string Id { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; } = null!;
    public IEnumerable<Package> Packages { get; set; } = [];
}
