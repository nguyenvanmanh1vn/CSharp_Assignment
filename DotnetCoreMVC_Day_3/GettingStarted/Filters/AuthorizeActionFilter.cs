using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GettingStarted.Filters
{
    public class AuthorizeActionFilter: IAuthorizationFilter
    {
            private readonly string _permission;

            public AuthorizeActionFilter(string permission)
            {
                _permission = permission;
            }

            public void OnAuthorization(AuthorizationFilterContext context)
            {
                Boolean isAuthorized = false;
                if (context.HttpContext.Session.GetString("rolename") != null)
                {
                    isAuthorized = CheckUserPermission(context.HttpContext.Session.GetString("rolename"), _permission);
                }
                if (!isAuthorized)
                {
                    context.Result = new UnauthorizedResult();
                }
            }

            private bool CheckUserPermission(string role, string permission)
            {
                // Logic for checking the user permission goes here.

                // Let's assume this user has only read permission.
                return permission.Contains(role);  
            }
    }
}
