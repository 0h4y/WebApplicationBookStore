using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationBookStore.Models;

public partial class Customer
{
    [Key]
    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string LastName { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Mail { get; set; } = null!;

    [InverseProperty("Customer")]
    public virtual ICollection<Order> Orders { get; } = new List<Order>();

    [ForeignKey("CustomerId")]
    [InverseProperty("Customers")]
    public virtual ICollection<Adress> Adresses { get; } = new List<Adress>();

    [ForeignKey("CustomerId")]
    [InverseProperty("Customers")]
    public virtual ICollection<Phone> Phones { get; } = new List<Phone>();
}
