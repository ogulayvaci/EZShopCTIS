using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

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
        category.name = category.name?.Trim();
        category.description = category.description?.Trim();
        _db.categories.Add(category);
        _db.SaveChanges();
        return Success();
    }

    public Service Update(category category)
    {
        if (_db.categories.Any(c => c.id != category.id && c.name == category.name))
            return Error("Category already exists");
        
        var entity = _db.categories.Find(category.id);
        entity.name = category.name?.Trim();
        entity.description = category.description?.Trim();
        _db.categories.Update(entity);
        return Success();
    }

    public Service Delete(int id)
    {
        var category = _db.categories.Include(c => c.products).SingleOrDefault(c => c.id == id);

        if (category is not null && category.products.Any())
            return Error("Category cannot be delete, it has relational products");
        
        _db.categories.Remove(category);
        _db.SaveChanges();
        return Success();
    }

    public IQueryable<CategoryModel> Query()
    {
        return _db.categories.OrderBy(c => c.name).Select(c => new CategoryModel() {Record = c});
    }
}