using System.Runtime.InteropServices.JavaScript;
using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services;

public interface IStoreService
{
    public IQueryable<StoreModel> Query();
    
    public Service Create(store store);
    
    public Service Update(store store);
    
    public Service Delete(int id);
}

public class StoreService : Service, IStoreService
{
    public StoreService(Db db) : base(db)
    {
    }

    public IQueryable<StoreModel> Query()
    {
        return _db.stores.Include(s=>s.country).Include(s=>s.city).OrderByDescending(s => s.isvirtual).ThenBy(s => s.name)
            .Select(s => new StoreModel() { Record = s });
    }

    public Service Create(store store)
    {
        if(_db.stores.Any(s => s.isvirtual == store.isvirtual && s.name.ToLower() == store.name.ToLower().Trim()))
            return Error("This store already exists.");
        _db.stores.Add(store);
        _db.SaveChanges();
        return Success("Store added.");
    }

    public Service Update(store store)
    {
        if(_db.stores.Any(s => s.id != store.id && s.isvirtual == store.isvirtual && s.name.ToLower() == store.name.ToLower().Trim()))
            return Error("This store already exists.");
        var entity = _db.stores.Find(store.id);
        if(entity == null)
            return Error("Store not found.");
        entity.name = store.name?.Trim();
        entity.isvirtual = store.isvirtual;
        _db.stores.Update(entity);
        _db.SaveChanges();
        return Success("Store updated.");
    }

    public Service Delete(int id)
    {
        var entity = _db.stores.Include(s=> s.productstores).SingleOrDefault(s=> s.id == id);
        if(entity == null)
            return Error("Store not found.");
        // _db.stores.RemoveRange(entity.productstores);
        _db.stores.Remove(entity);
        _db.SaveChanges();
        return Success("Store deleted.");
        
        
    }
}