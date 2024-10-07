using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BLL.DAL;

public partial class product
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
    [InverseProperty("product")]
    public virtual category category { get; set; } = null!;

    [InverseProperty("product")]
    public virtual ICollection<productstore> productstores { get; set; } = new List<productstore>();
}
