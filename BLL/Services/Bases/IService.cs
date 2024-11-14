namespace BLL.Services.Bases;

public interface IService<TEntity, TModel> where TEntity : class, new() where TModel : class, new()
{
    public IQueryable<TModel> Query(); // where TModel : class, new()
    public Service Create(TEntity entity); // where TEntity : class, new()
    public Service Update(TEntity entity);
    public Service Delete(int id);
}