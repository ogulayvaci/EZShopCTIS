#nullable disable
using BLL.DAL;

namespace BLL.Models;

public class CategoryModel
{
    public categories Record { get; set; }

    public String Name => Record.name;

    public String Description => Record.description;
}