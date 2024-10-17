using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;

namespace BLL.Services;

public interface ICategoryService
{
    public Service Create(category category);
    public Service Update(category category);
    public Service Delete(int id);
    public IQueryable<CategoryModel> Query();
}

public class CategoryService: Service, ICategoryService
{
    public CategoryService(Db db) : base(db) // base: super in Java
    {
    }

    public Service Create(category category)
    {
        if (_db.categories.Any(c => c.name == category.name))
            return Error("Category already exists");
        _db.categories.Add(category);
        _db.SaveChanges();
        return Success();
    }

    public Service Update(category category)
    {
        _db.categories.Update(category);
        _db.SaveChanges();
        return Success();
    }

    public Service Delete(int id)
    {
        var category = _db.categories.Find(id);
        _db.categories.Remove(category);
        _db.SaveChanges();
        return Success();
    }

    public IQueryable<CategoryModel> Query()
    {
        return _db.categories.OrderBy(c => c.name).Select(c => new CategoryModel() {Record = c});
    }
}