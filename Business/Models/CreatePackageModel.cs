namespace Business.Models;

public class CreatePackageModel
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string Seating { get; set; } = null!;
    public decimal? Price { get; set; }
    public string? Currency { get; set; }
    public string EventId { get; set; } = null!;
}
