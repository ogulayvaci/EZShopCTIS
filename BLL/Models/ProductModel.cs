#nullable disable
using System.ComponentModel;
using BLL.DAL;
namespace BLL.Models;

public class ProductModel
{
    public product Record { get; set; }

    [DisplayName("Product Name")]
    public string Name => Record.name;
    
    [DisplayName("Unit Price")]
    public string UnitPrice => Record.unitprice.ToString("C2");

    [DisplayName("Stock Amount")]
    public int StockAmount => Record.stockamount ?? 0;

    [DisplayName("Expiration Date")]
    public string ExpirationDate => Record.expirationdate.HasValue ? Record.expirationdate.Value.ToString("MM/dd/yyyy") : string.Empty;

    public string Category => Record.category?.name;

    public string Stores => string.Join("<br>", Record.productstores?.Select(ps => ps.store?.name));

    [DisplayName("Stores")]
    public List<int> StoreIds
    {
        get => Record.productstores?.Select(ps => ps.storeid).ToList();
        set => Record.productstores = value.Select(v => new productstore() { storeid = v }).ToList();
    }
    
}