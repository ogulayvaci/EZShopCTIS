using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BLL.DAL;

public partial class user
{
    [Key]
    public int id { get; set; }

    [StringLength(10)]
    public string username { get; set; } = null!;

    [StringLength(8)]
    public string password { get; set; } = null!;

    public bool isactive { get; set; }

    public int roleid { get; set; }

  
    public virtual role role { get; set; } = null!;
}
