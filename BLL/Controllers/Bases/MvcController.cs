using System.Globalization;
using Microsoft.AspNetCore.Mvc;

namespace BLL.Controllers;

// to add Controller edit BLL.csproj with vscode and add
// <ItemGroup>
//   <FrameworkReference Include="Microsoft.AspNetCore.App" />
// </ItemGroup>
public abstract class MvcController : Controller 
{
    protected MvcController()
    {
        var cultureInfo= new CultureInfo("en-US");
        Thread.CurrentThread.CurrentCulture = cultureInfo;
        Thread.CurrentThread.CurrentUICulture = cultureInfo;
    }
    
}