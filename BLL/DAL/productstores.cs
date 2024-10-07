using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BLL.DAL;

public partial class productstores
{
    [Key]
    public int id { get; set; }

    public int productid { get; set; }

    public int storeid { get; set; }

    [ForeignKey("productid")]
    [InverseProperty("productstores")]
    public virtual products product { get; set; } = null!;

    [ForeignKey("storeid")]
    [InverseProperty("productstores")]
    public virtual stores store { get; set; } = null!;
}
