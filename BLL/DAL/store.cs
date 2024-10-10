using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BLL.DAL;

public partial class store
{
    [Key]
    public int id { get; set; }

    [StringLength(200)]
    public string name { get; set; } = null!;

    public bool isvirtual { get; set; }

    public int? countryid { get; set; }

    public int? cityid { get; set; }

    public virtual city? city { get; set; }


    public virtual country? country { get; set; }


    public virtual ICollection<productstore> productstores { get; set; } = new List<productstore>();
}
