using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BLL.DAL;

public partial class roles
{
    [Key]
    public int id { get; set; }

    [StringLength(5)]
    public string rolename { get; set; } = null!;

    [InverseProperty("role")]
    public virtual ICollection<users> users { get; set; } = new List<users>();
}
