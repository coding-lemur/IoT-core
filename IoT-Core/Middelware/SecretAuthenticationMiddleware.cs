using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace IoT_Core.Middelware
{
    /// <summary>
    /// Accepts either username or email as user identifier for sign in with Http Basic authentication
    /// </summary>
    public class SecretAuthenticationMiddleware
    {
        private const string HEADER_KEY = "secret";
        private const string SECRET_VALUE = "ESP8266";

        private readonly RequestDelegate _next;

        public SecretAuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Headers.ContainsKey(HEADER_KEY))
            {
                // revoke request
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return;
            }

            var secret = context.Request.Headers[HEADER_KEY];
            if (secret != SECRET_VALUE)
            {
                // revoke request
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return;
            }

            // accept request
            await _next.Invoke(context);
        }
    }
}
