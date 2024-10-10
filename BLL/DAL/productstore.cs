using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BLL.DAL;

public partial class productstore
{
    [Key]
    public int id { get; set; }

    public int productid { get; set; }

    public int storeid { get; set; }


    public virtual product product { get; set; } = null!;


    public virtual store store { get; set; } = null!;
}
