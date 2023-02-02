using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationBookStore.Models;

public partial class Phone
{
    [Key]
    [Column("PhoneID")]
    public int PhoneId { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string PhoneNumber { get; set; } = null!;

    [ForeignKey("PhoneId")]
    [InverseProperty("Phones")]
    public virtual ICollection<Customer> Customers { get; } = new List<Customer>();
}
