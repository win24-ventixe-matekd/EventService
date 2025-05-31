﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class EventEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Title { get; set; } = null!;
    public string? Description { get; set; }

    [Column(TypeName = "datetime2")]
    public DateTime Date { get; set; }
    public string Location { get; set; } = null!;
    public ICollection<PackageEntity> Packages { get; set; } = [];
}
