using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BLL.DAL;

public partial class category
{
    [Key]
    public int id { get; set; }

    [StringLength(100)]
    public string name { get; set; } = null!;

    public string? description { get; set; }
    public virtual ICollection<product> products { get; set; } = new List<product>();
}
