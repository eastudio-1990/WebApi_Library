using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Library.Application.Middleware
{
    public class RoleBasedAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public RoleBasedAuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var userRole = context.User?.FindFirst(ClaimTypes.Role)?.Value;

            if (userRole == "Admin")
            {
                await _next(context); // Admin can access everything
            }
            else
            {
                // User role logic
                if (context.Request.Path.StartsWithSegments("/api/admin"))
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    await context.Response.WriteAsync("Access denied");
                    return;
                }
                await _next(context);
            }
        }
    }
}
