using DemoDAL.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductWebAPI.Infrastructure
{
    public class AuthRequiredAttribute : TypeFilterAttribute
    {
        public AuthRequiredAttribute() : base(typeof(AuthRequiredFilter))
        {

        }
    }

    public class AuthRequiredFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            context.HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues authorizations);

            string token = authorizations.SingleOrDefault(auth => auth.StartsWith("Bearer "));
            TokenService tokenService = (TokenService)context.HttpContext.RequestServices.GetService(typeof(TokenService));

            if (token is null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            User user = tokenService.VerifyToken(token);

            if (user is null)
                context.Result = new UnauthorizedResult();
            
        }
    }
}
