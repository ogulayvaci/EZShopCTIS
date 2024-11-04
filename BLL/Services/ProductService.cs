#nullable enable
using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services;

public interface IProductService
{
    public Service Create(product product);
    public Service Update(product product);
    public Service Delete(int id);
    public IQueryable<ProductModel> Query();
}

public class ProductService: Service, IProductService
{
    public ProductService(Db db) : base(db)
    {
    }
    
    public IQueryable<ProductModel> Query()
    {
        return _db.products.Include(p => p.category).OrderByDescending(p => p.expirationdate).ThenBy(p => p.stockamount).ThenBy(p => p.name).Select(p => new ProductModel() { Record = p });
    }

    public Service Create(product product)
    {
        if (_db.products.Any(p => p.name.ToUpper() == product.name.ToUpper().Trim()))
            return Error("Product with the same name exists!");
        if (product.stockamount.HasValue && product.stockamount.Value < 0)
            return Error("Stock amount must be a positive number!");
        product.name = product.name?.Trim();
        _db.products.Add(product);
        _db.SaveChanges();
        return Success("Product created successfully.");
    }

    public Service Update(product product)
    {
        if (_db.products.Any(p => p.id != product.id && p.name.ToUpper() == product.name.ToUpper().Trim()))
            return Error("Product with the same name exists!");
        if (product.stockamount.HasValue && product.stockamount.Value < 0)
            return Error("Stock amount must be a positive number!");
        var entity = _db.products.SingleOrDefault(p => p.id == product.id);
        if (entity is null)
            return Error("Product not found!");
        entity.name = product.name?.Trim();
        entity.unitprice = product.unitprice;
        entity.stockamount = product.stockamount;
        entity.expirationdate = product.expirationdate;
        entity.categoryid = product.categoryid;
        _db.products.Update(entity);
        _db.SaveChanges();
        return Success("Product updated successfully.");
    }

    public Service Delete(int id)
    {
        // Way 1:
        //var product = _db.Products.Where(p => p.Id == id).SingleOrDefault();
        // Way 2:
        var product = _db.products.Include(p => p.productstores).SingleOrDefault(p => p.id == id);
        if (product is null)
            return Error("Product not found!");
        _db.productstores.RemoveRange(product.productstores);
        _db.products.Remove(product);
        _db.SaveChanges();
        return Success("Product deleted successfully.");
    }
}