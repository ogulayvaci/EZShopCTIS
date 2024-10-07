using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BLL.DAL;

public partial class cities
{
    [Key]
    public int id { get; set; }

    [StringLength(125)]
    public string name { get; set; } = null!;

    public int countryid { get; set; }

    [ForeignKey("countryid")]
    [InverseProperty("cities")]
    public virtual countries country { get; set; } = null!;

    [InverseProperty("city")]
    public virtual ICollection<stores> stores { get; set; } = new List<stores>();
}
