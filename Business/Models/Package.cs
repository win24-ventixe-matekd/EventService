namespace Business.Models;

public class Package
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Seating { get; set; } = null!;
    public decimal? Price { get; set; }
    public string? Currency { get; set; }
    public Event? Event { get; set; }
}
