using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationBookStore.Models;

public partial class Book
{
    [Key]
    [Column("ISBN")]
    [StringLength(17)]
    [Unicode(false)]
    public string Isbn { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Title { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string? Language { get; set; }

    [Column(TypeName = "money")]
    public decimal? Price { get; set; }

    [Column(TypeName = "date")]
    public DateTime? ReleaseDate { get; set; }

    [InverseProperty("IsbnNavigation")]
    public virtual ICollection<Inventory> Inventories { get; } = new List<Inventory>();

    [InverseProperty("IsbnNavigation")]
    public virtual ICollection<OrderRow> OrderRows { get; } = new List<OrderRow>();

    [ForeignKey("Isbn")]
    [InverseProperty("Isbns")]
    public virtual ICollection<Writer> Writers { get; } = new List<Writer>();
}
