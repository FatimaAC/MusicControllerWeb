using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using MusicController.Common.Enumerration;
using MusicController.DTO.APiResponesClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicController.Shared.ExpectionHelper
{
    public static class CustomAuthorizeFilter  
    {
        public static async Task CustomUnauthorized(this IApplicationBuilder app)
        {
            app.UseStatusCodePages(async context =>
            {
                if (context.HttpContext.Response.StatusCode == 401)
                {
                    await context.HttpContext.Response.WriteAsync(new Response<string>("Authorization failed.", StatusApiEnum.Failure).ToString());
                }
                else if (context.HttpContext.Response.StatusCode == 404)
                {
                    await context.HttpContext.Response.WriteAsync(new Response<string>("Not Found", StatusApiEnum.Failure).ToString());
                }
            });
        }
    }
}
