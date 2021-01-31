using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using MusicController.Common.Enumerration;
using MusicController.DTO.APiResponesClass;
using System.Threading.Tasks;

namespace MusicController.Shared.ExpectionHelper
{
    // customized response for APi in json Format and for other Status Type Error
    public static class CustomAuthorizeFilter
    {
        public static async Task CustomUnauthorized(this IApplicationBuilder app)
        {
            app.UseStatusCodePages(async context =>
            {
                context.HttpContext.Response.ContentType = "application/json";
                switch (context.HttpContext.Response.StatusCode)
                {
                    case 401:
                        await context.HttpContext.Response.WriteAsync(new Response<string>("Authorization failed.", StatusApiEnum.Failure).ToString());
                        break;
                    case 404:
                        await context.HttpContext.Response.WriteAsync(new Response<string>("Not Found", StatusApiEnum.Failure).ToString());
                        break;
                    case 403:
                        await context.HttpContext.Response.WriteAsync(new Response<string>("Forbiden", StatusApiEnum.Failure).ToString());
                        break;
                    default:
                        break;
                }
            });
        }
    }
}
