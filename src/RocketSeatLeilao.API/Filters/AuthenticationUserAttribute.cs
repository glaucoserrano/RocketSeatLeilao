using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RocketSeatLeilao.API.Contracts;

namespace RocketSeatLeilao.API.Filters;

public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    private IUserRepository _respotory;

    public AuthenticationUserAttribute(IUserRepository respotory) => _respotory = respotory;

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        try
        {
            var token = TokenOnRequest(context.HttpContext);


            var email = FromBase64String(token);
            var exists = _respotory.ExistUserWithEmail(email);

            if (exists == false)
            {
                context.Result = new UnauthorizedObjectResult("Email not valid");
            }

        }
        catch(Exception ex)
        {
            context.Result = new UnauthorizedObjectResult(ex.Message);
        }
    }
    private string TokenOnRequest(HttpContext context)
    {
        var authentication = context.Request.Headers.Authorization.ToString();

        if (string.IsNullOrEmpty(authentication))
            throw new Exception("Token is missing");
        

        return authentication["Bearer ".Length..];    
    }
    private string FromBase64String(string Base64)
    {
        var data = Convert.FromBase64String(Base64);
        return System.Text.Encoding.UTF8.GetString(data);
    }
}

