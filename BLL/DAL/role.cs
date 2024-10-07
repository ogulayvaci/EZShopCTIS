using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BLL.DAL;

public partial class role
{
    [Key]
    public int id { get; set; }

    [StringLength(5)]
    public string rolename { get; set; } = null!;

    [InverseProperty("role")]
    public virtual ICollection<user> users { get; set; } = new List<user>();
}
