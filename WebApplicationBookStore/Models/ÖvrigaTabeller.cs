using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationBookStore.Models;

[Keyless]
public partial class ÖvrigaTabeller
{
    [Column("Order nr.")]
    public int? OrderNr { get; set; }

    [StringLength(101)]
    [Unicode(false)]
    public string? Namn { get; set; }

    [StringLength(226)]
    [Unicode(false)]
    public string Expr1 { get; set; } = null!;

    [Column("Tel.")]
    [StringLength(15)]
    [Unicode(false)]
    public string? Tel { get; set; }

    [Column("Antal böcker på ordern")]
    public int? AntalBöckerPåOrdern { get; set; }

    [StringLength(8000)]
    [Unicode(false)]
    public string? Titlar { get; set; }

    [Column("Faktura Total", TypeName = "money")]
    public decimal? FakturaTotal { get; set; }
}
