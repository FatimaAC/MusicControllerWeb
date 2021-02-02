using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MusicController.Common.Enumerration;
using MusicController.DTO.APiResponesClass;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MusicController.Shared.ExpectionHelper
{
    // Customized Expection Handling for Web APi
    public static class ExceptionHandler
    {
        public static void UseApiExceptionHandler(this IApplicationBuilder app, ILogger loggerFactory)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature.Error is UserFriendlyException httpException)
                    {
                        if (contextFeature != null)
                        {
                            //Technical Exception for troubleshooting
                           
                            //Business exception - exit gracefully
                            await context.Response.WriteAsync(new Response<string>(contextFeature.Error.Message, (StatusApiEnum)httpException.StatusCode).ToString());
                        }
                    }
                    else
                    {
                        var sb = new StringBuilder();
                        sb.AppendLine("GlobalException");
                        sb.AppendLine($"Something went wrong :{contextFeature.Error}");
                        loggerFactory.LogError(sb.ToString());
                        await context.Response.WriteAsync(new Response<string>("Something went wrong").ToString());
                    }
                });
            });
        }
        public static void UseApiValidationHandler(this IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
            }).ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = (context) =>
                {
                    var errorDetails = new ErrorDetails
                    {
                        StatusCode = StatusApiEnum.Failure
                    };
                    foreach (var modelStateKey in context.ModelState.Keys)
                    {
                        var modelStateVal = context.ModelState[modelStateKey];
                        var validationError = new ValidationError
                        {
                            Key = modelStateKey
                        };
                        foreach (var error in modelStateVal.Errors)
                        {
                            validationError.ErrorMessage = error.ErrorMessage;
                            // You may log the errors if you want
                        }
                        errorDetails.ValidationErrors.Add(validationError);
                    }
                    return new BadRequestObjectResult(errorDetails);
                };
            });
        }
    }
    public class ErrorDetails
    {
        public ErrorDetails()
        {
            ValidationErrors = new List<ValidationError>();
        }
        public StatusApiEnum StatusCode { get; set; }
        public string Message { get; set; }
        public List<ValidationError> ValidationErrors { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class ValidationError
    {
        public string Key { get; set; }
        public string ErrorMessage { get; set; }
    }

}
