using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoT_Core.Middelware
{
    /// <summary>
    /// Accepts either username or email as user identifier for sign in with Http Basic authentication
    /// </summary>
    public class SecretAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public SecretAuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var secret = context.Request.Headers["secret"];

            if (secret != "ESP8266")
            {
                // revoke request
                context.Response.StatusCode = 400;
                return;
            }

            await _next.Invoke(context);
        }
    }
}
