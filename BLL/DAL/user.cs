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

    [Required]
    [StringLength(10)]
    public string username { get; set; }

    [StringLength(8)]
    public string password { get; set; }

    public bool isactive { get; set; }

    public int roleid { get; set; }
    public virtual role role { get; set; }
}
