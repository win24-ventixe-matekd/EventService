using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class PackageEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string Seating { get; set; } = null!;

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Price { get; set; }
    public string? Currency { get; set; }

    [ForeignKey(nameof(Event))]
    public string EventId { get; set; } = null!;
    public EventEntity Event { get; set; } = null!;
}