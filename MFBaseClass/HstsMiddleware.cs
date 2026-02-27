using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class HstsMiddleware
{
    private readonly RequestDelegate _next;

    public HstsMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        context.Response.Headers.Append("Strict-Transport-Security", "max-age=31536000; includeSubDomains; preload");
        await _next(context);
    }
}
