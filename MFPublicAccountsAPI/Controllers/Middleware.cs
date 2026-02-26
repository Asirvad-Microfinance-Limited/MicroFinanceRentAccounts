using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFPublicAccountsAPI.Controllers
{
    public class Middleware
    {
        private readonly RequestDelegate _next;
        private readonly ConcurrentDictionary<string, int> _requestCounts;
        private readonly int _rateLimit;
        private readonly TimeSpan _timeGap;

        public Middleware(RequestDelegate next)
        {
            _next = next;
            _requestCounts = new ConcurrentDictionary<string, int>();
            _rateLimit = 2;
            _timeGap = TimeSpan.FromSeconds(1);
        }

        public async Task Invoke(HttpContext context)
        {



            // Check if the request is a GET method
            if (context.Request.Method.ToUpper() == "POST" || context.Request.Method.ToUpper() == "GET")
            {
                // Get the client IP address
                var ipAddress = context.Connection.RemoteIpAddress?.ToString();

                // Increment the request count for the client IP
                _requestCounts.AddOrUpdate(ipAddress, 1, (_, existingCount) => existingCount + 1);

                // Check if the request count exceeds the rate limit within the specified time gap
                if (_requestCounts.TryGetValue(ipAddress, out var currentCount) && currentCount > _rateLimit)
                {
                    // Calculate the earliest time when the rate limit will reset
                    var earliestResetTime = DateTime.Now.Add(_timeGap.Negate());

                    // Check if the earliest reset time has passed
                    if (_requestCounts.TryRemove(ipAddress, out _))
                    {
                        _requestCounts.AddOrUpdate(ipAddress, 1, (_, __) => 1);
                    }

                    // Return a 429 Too Many Requests response with the earliest reset time
                    context.Response.Headers.Add("Retry-After", earliestResetTime.ToString("R"));
                    context.Response.StatusCode = 429;
                    await context.Response.WriteAsync($"Rate limit exceeded. Please try again after {earliestResetTime.ToString("R")}.");
                    return;
                }
            }

            await _next(context);
        }

        //    var ipAddress = context.Connection.RemoteIpAddress?.ToString();
        //    var requestPath = context.Request.Path;

        //    var cacheKey = $"{ipAddress}:{requestPath}";

        //    if (!_cache.TryGetValue(cacheKey, out int requestCount))
        //    {
        //        requestCount = 0;
        //    }

        //    requestCount++;

        //    // Apply rate limiting logic
        //    var limit = 2; // Maximum number of requests allowed per minute

        //    if (requestCount > limit)
        //    {
        //        context.Response.StatusCode = 429; // Too Many Requests
        //        await context.Response.WriteAsync("Rate limit exceeded.");
        //        return;
        //    }

        //    var cacheEntryOptions = new MemoryCacheEntryOptions()
        //        .SetAbsoluteExpiration(TimeSpan.FromSeconds(60)); // Time period to count the requests

        //    _cache.Set(cacheKey, requestCount, cacheEntryOptions);

        //    await _next(context);
        //}

    }
}
