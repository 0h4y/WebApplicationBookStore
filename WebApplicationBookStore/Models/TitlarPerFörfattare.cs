using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationBookStore.Models;

[Keyless]
public partial class TitlarPerFörfattare
{
    [StringLength(101)]
    public string? Namn { get; set; }

    [StringLength(33)]
    [Unicode(false)]
    public string? Ålder { get; set; }

    [StringLength(33)]
    [Unicode(false)]
    public string? Titlar { get; set; }

    [StringLength(4000)]
    public string? Lagervärde { get; set; }
}
