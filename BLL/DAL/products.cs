using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BLL.DAL;

public partial class products
{
    [Key]
    public int id { get; set; }

    [StringLength(150)]
    public string name { get; set; } = null!;

    [Precision(18, 2)]
    public decimal unitprice { get; set; }

    public int? stockamount { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? expirationdate { get; set; }

    public int categoryid { get; set; }

    [ForeignKey("categoryid")]
    [InverseProperty("products")]
    public virtual categories category { get; set; } = null!;

    [InverseProperty("product")]
    public virtual ICollection<productstores> productstores { get; set; } = new List<productstores>();
}
