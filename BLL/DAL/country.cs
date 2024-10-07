using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BLL.DAL;

public partial class country
{
    [Key]
    public int id { get; set; }

    [StringLength(100)]
    public string name { get; set; } = null!;

    [InverseProperty("country")]
    public virtual ICollection<city> cities { get; set; } = new List<city>();

    [InverseProperty("country")]
    public virtual ICollection<store> stores { get; set; } = new List<store>();
}
