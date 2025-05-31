using Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Models;

public class Package
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Seeting { get; set; } = null!;
    public decimal? Price { get; set; }
    public string? Currency { get; set; }
}
