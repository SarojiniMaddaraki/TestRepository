using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;
using System.Net;

namespace ToDoApplication.Services
{
    public class SwaggerKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string APIKEYNAME = "apikey";
        public SwaggerKeyMiddleware(RequestDelegate next) => _next = next;
        //public async Task InvokeAsync(HttpContext context)
        //{
        //var endpoint = context.GetEndpoint();

        //if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
        //{
        //    await _next(context);
        //    return;
        //}
        //string referer = context.Request.Headers["Referer"].ToString();
        //    // ONLY enforce this check if the request is coming from the Swagger UI
        //    if (!string.IsNullOrEmpty(referer) && referer.Contains("/swagger"))
        //    {
        //        if (!context.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
        //        {
        //            context.Response.StatusCode = 401;
        //            await context.Response.WriteAsync("API Key missing. Please use the 'Authorize' button in Swagger.");
        //            return;
        //        }
        //        var actualKey = Environment.GetEnvironmentVariable("SWAGGER_API_KEY");
        //        if (actualKey == null || !actualKey.Equals(extractedApiKey))
        //        {
        //            context.Response.StatusCode = 401;
        //            await context.Response.WriteAsync("Invalid API Key.");
        //            return;
        //        }
        //    }
        //    await _next(context);
        //}

        //public async Task InvokeAsync(HttpContext context)
        //    {
        //        // 1. Get the current endpoint from the context
        //        var endpoint = context.GetEndpoint();

        //        // 2. Check if the endpoint has the [AllowAnonymous] attribute
        //        // Note: This only works if this middleware is placed AFTER app.UseRouting()
        //        if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
        //        {
        //            await _next(context);
        //            return;
        //        }

        //        string referer = context.Request.Headers["Referer"].ToString();
        //            bool hasApiKey = context.Request.Headers.TryGetValue("api_key", out var extractedApiKeytest);
        //            bool hasBearer = context.Request.Headers.ContainsKey("Authorization");

        //            // 3. Only check for API Key if the request is from Swagger UI 
        //            // AND the endpoint is NOT public
        //            if (!string.IsNullOrEmpty(referer) && referer.Contains("/swagger"))
        //        {
        //            if (!context.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
        //            {
        //                context.Response.StatusCode = 401;
        //                await context.Response.WriteAsync("API Key missing. Please use the 'Authorize' button in Swagger.");
        //                return;
        //            }

        //            var actualKey = Environment.GetEnvironmentVariable("SWAGGER_API_KEY");
        //            if (actualKey == null || !actualKey.Equals(extractedApiKey.ToString()))
        //            {
        //                context.Response.StatusCode = 401;
        //                await context.Response.WriteAsync("Invalid API Key.");
        //                return;
        //            }
        //        }

        //        await _next(context);
        //    }

        public async Task InvokeAsync(HttpContext context)
        {
            // 1. If it's a public endpoint ([AllowAnonymous]), just let it through
            var endpoint = context.GetEndpoint();
            if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
            {
                await _next(context);
                return;
            }

            string referer = context.Request.Headers["Referer"].ToString();

            // 2. Only run Swagger-specific checks
            if (!string.IsNullOrEmpty(referer) && referer.Contains("/swagger"))
            {
                // Check for Bearer token
                if (context.Request.Headers.ContainsKey("Authorization"))
                {
                    // HAND-OFF: We found a Bearer token! 
                    // Stop this middleware and let app.UseAuthentication() check if the token is valid.
                    await _next(context);
                    return;
                }

                // 3. ONLY if Bearer is missing do we look for the API Key
                if (!context.Request.Headers.TryGetValue("api_key", out var extractedApiKey))
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("API Key or Bearer Token missing.");
                    return;
                }

                // Validate API Key (if provided)
                var actualKey = Environment.GetEnvironmentVariable("SWAGGER_API_KEY");
                if (actualKey == null || !actualKey.Equals(extractedApiKey.ToString()))
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Invalid API Key.");
                    return;
                }
            }

            await _next(context);
        }


    }

}
