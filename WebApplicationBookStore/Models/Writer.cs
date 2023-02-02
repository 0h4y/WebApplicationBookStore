using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationBookStore.Models;

public partial class Writer
{
    [Key]
    [Column("WriterID")]
    public int WriterId { get; set; }

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [Column(TypeName = "date")]
    public DateTime BirthDate { get; set; }

    [Column(TypeName = "date")]
    public DateTime? DeathDate { get; set; }

    public int? AgeCalculated { get; set; }

    [ForeignKey("WriterId")]
    [InverseProperty("Writers")]
    public virtual ICollection<Book> Isbns { get; } = new List<Book>();
}
