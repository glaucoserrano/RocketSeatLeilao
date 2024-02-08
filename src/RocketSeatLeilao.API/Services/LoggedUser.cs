using RocketSeatLeilao.API.Contracts;
using RocketSeatLeilao.API.Entities;

namespace RocketSeatLeilao.API.Services;

public class LoggedUser : ILoggedUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserRepository _respository;
    public LoggedUser(IHttpContextAccessor httpContext,IUserRepository repository)
    {
        _httpContextAccessor = httpContext;
        _respository = repository;
    }
    public User User()
    {
        var token = TokenOnRequest();

        var email = FromBase64String(token);
        return _respository.GetUserByEmail(email);
    }

    private string TokenOnRequest()
    {
        var authentication = _httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();

        return authentication["Bearer ".Length..];
    }
    private string FromBase64String(string Base64)
    {
        var data = Convert.FromBase64String(Base64);
        return System.Text.Encoding.UTF8.GetString(data);
    }
}
