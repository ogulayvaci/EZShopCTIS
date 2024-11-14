using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;

namespace BLL.Services;

// public interface IUserService
// {
//         public IQueryable<UserModel> Query();
//         public Service Create(user user);
//         public Service Update(user user);
//         public Service Delete(int id);
//         
// }



public class UserService : Service, IService<user, UserModel>
{
    public UserService(Db db) : base(db)
    {
    }

    /// <summary>
    /// this will return the active users
    /// </summary>
    public IQueryable<UserModel> Query()
    {
        return _db.users.Where(u=>u.isactive).Select(u => new UserModel() { Record = u });
    }

    public Service Create(user entity)
    {
        throw new NotImplementedException();
    }

    public Service Update(user entity)
    {
        throw new NotImplementedException();
    }

    public Service Delete(int id)
    {
        throw new NotImplementedException();
    }
}