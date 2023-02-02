using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationBookStore.Models;

[PrimaryKey("OrderId", "Isbn")]
public partial class OrderRow
{
    [Key]
    [Column("OrderID")]
    public int OrderId { get; set; }

    [Key]
    [Column("ISBN")]
    [StringLength(17)]
    [Unicode(false)]
    public string Isbn { get; set; } = null!;

    public int Amount { get; set; }

    [Column(TypeName = "money")]
    public decimal TotalPrice { get; set; }

    [ForeignKey("Isbn")]
    [InverseProperty("OrderRows")]
    public virtual Book IsbnNavigation { get; set; } = null!;

    [ForeignKey("OrderId")]
    [InverseProperty("OrderRows")]
    public virtual Order Order { get; set; } = null!;
}
