using System.ComponentModel;
using BLL.DAL;

namespace BLL.Models;

public class StoreModel
{
    public store Record { get; set; }

    public String Name => Record.name;
    
    [DisplayName("Virtual")]
    public String IsVirtual => Record.isvirtual ? "Yes" : "No";

    [DisplayName("Country City")]
    public String  CountryAndCity => Record.country?.name + ", " + Record.city?.name;
}