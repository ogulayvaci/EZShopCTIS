using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BLL.DAL;

public partial class city
{
    [Key]
    public int id { get; set; }

    [StringLength(125)]
    public string name { get; set; } = null!;

    public int countryid { get; set; }
    
    public virtual country country { get; set; } = null!;
    
    public virtual ICollection<store> stores { get; set; } = new List<store>();
}
