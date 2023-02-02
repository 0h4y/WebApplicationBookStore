using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationBookStore.Models;

public partial class Adress
{
    [Key]
    [Column("AdressID")]
    public int AdressId { get; set; }

    [Column("Adress")]
    [StringLength(100)]
    [Unicode(false)]
    public string Adress1 { get; set; } = null!;

    [Column("ZIP")]
    [StringLength(20)]
    [Unicode(false)]
    public string Zip { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string City { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Country { get; set; } = null!;

    [ForeignKey("AdressId")]
    [InverseProperty("Adresses")]
    public virtual ICollection<Customer> Customers { get; } = new List<Customer>();
}
