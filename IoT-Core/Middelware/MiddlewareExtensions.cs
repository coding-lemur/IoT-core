using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoT_Core.Middelware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseSecretAuthentication(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SecretAuthenticationMiddleware>();
        }
    }
}
