using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BLL.DAL;

public partial class stores
{
    [Key]
    public int id { get; set; }

    [StringLength(200)]
    public string name { get; set; } = null!;

    public bool isvirtual { get; set; }

    public int? countryid { get; set; }

    public int? cityid { get; set; }

    [ForeignKey("cityid")]
    [InverseProperty("stores")]
    public virtual cities? city { get; set; }

    [ForeignKey("countryid")]
    [InverseProperty("stores")]
    public virtual countries? country { get; set; }

    [InverseProperty("store")]
    public virtual ICollection<productstores> productstores { get; set; } = new List<productstores>();
}
