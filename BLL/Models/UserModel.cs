using BLL.DAL;

namespace BLL.Models;

public class UserModel
{
    public user Record { get; set; }

    public string username => Record.username;

    public string password => Record.password;
    
    public string isactive => Record.isactive ? "Active" : "Inactive";
    
    public string role => Record.role?.rolename;
}