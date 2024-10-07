using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BLL.DAL;

public partial class countries
{
    [Key]
    public int id { get; set; }

    [StringLength(100)]
    public string name { get; set; } = null!;

    [InverseProperty("country")]
    public virtual ICollection<cities> cities { get; set; } = new List<cities>();

    [InverseProperty("country")]
    public virtual ICollection<stores> stores { get; set; } = new List<stores>();
}
