using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationBookStore.Models;

public partial class Store
{
    [Key]
    [Column("StoreID")]
    public int StoreId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string? Adress { get; set; }

    [Column("ZIP")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Zip { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? City { get; set; }

    [InverseProperty("Store")]
    public virtual ICollection<Inventory> Inventories { get; } = new List<Inventory>();

    [InverseProperty("Store")]
    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
