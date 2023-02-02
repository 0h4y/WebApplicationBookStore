using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationBookStore.Models;

public partial class Order
{
    [Key]
    [Column("OrderID")]
    public int OrderId { get; set; }

    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Column("StoreID")]
    public int StoreId { get; set; }

    [Precision(0)]
    public DateTime DateTime { get; set; }

    [Column(TypeName = "money")]
    public decimal Total { get; set; }

    [Column(TypeName = "money")]
    public decimal Paid { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("Orders")]
    public virtual Customer Customer { get; set; } = null!;

    [InverseProperty("Order")]
    public virtual ICollection<OrderRow> OrderRows { get; } = new List<OrderRow>();

    [ForeignKey("StoreId")]
    [InverseProperty("Orders")]
    public virtual Store Store { get; set; } = null!;
}
