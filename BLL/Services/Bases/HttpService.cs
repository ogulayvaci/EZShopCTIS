using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BLL.Services.Bases;

public abstract class HttpServiceBase
{
    
    string SESSION_KEY = "SESSION_KEY";
    private readonly HttpContextAccessor _httpContextAccessor;

    protected HttpServiceBase(HttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public virtual T GetSession<T>() where T : class, new()
    {
        string json = _httpContextAccessor.HttpContext.Session.GetString(SESSION_KEY);

        T instance = null;
        if (!string.IsNullOrWhiteSpace(json))
            instance = JsonConvert.DeserializeObject<T>(json);
        return instance;
    }

    public virtual void SetSession<T>(T instance) where T : class, new()
    {
        string json = JsonConvert.SerializeObject(instance);
        _httpContextAccessor.HttpContext.Session.SetString(SESSION_KEY, json);
    }
}

public class HttpService : HttpServiceBase
{
    public HttpService(HttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        
    }
}