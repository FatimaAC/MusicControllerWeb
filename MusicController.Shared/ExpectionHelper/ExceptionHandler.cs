using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;

namespace MusicController.Shared.ExpectionHelper
{
    public static class ExceptionHandler
    {
        public static void UseApiExceptionHandler(this IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    //if any exception then report it and log it
                    if (contextFeature != null)
                    {
                        //Technical Exception for troubleshooting
                        var logger = loggerFactory.CreateLogger("GlobalException");
                        logger.LogError($"Something went wrong: {contextFeature.Error}");

                        //Business exception - exit gracefully
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message
                        }.ToString());
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
                        StatusCode = 400
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
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public List<ValidationError> ValidationErrors { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class ValidationError{
        public string Key { get; set; }
        public string ErrorMessage { get; set; }
}

}
