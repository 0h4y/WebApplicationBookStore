using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationBookStore.Models;

[PrimaryKey("StoreId", "Isbn")]
public partial class Inventory
{
    [Key]
    [Column("StoreID")]
    public int StoreId { get; set; }

    [Key]
    [Column("ISBN")]
    [StringLength(17)]
    [Unicode(false)]
    public string Isbn { get; set; } = null!;

    public int? Amount { get; set; }

    [ForeignKey("Isbn")]
    [InverseProperty("Inventories")]
    public virtual Book IsbnNavigation { get; set; } = null!;

    [ForeignKey("StoreId")]
    [InverseProperty("Inventories")]
    public virtual Store Store { get; set; } = null!;
}
