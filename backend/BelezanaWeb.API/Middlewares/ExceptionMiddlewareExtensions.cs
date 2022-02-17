using BelezanaWeb.SystemObjects.Exceptions;
using BelezanaWeb.SystemObjects.ViewModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Mime;

namespace BelezanaWeb.Middlewares
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            var logger = loggerFactory.CreateLogger(typeof(ExceptionMiddlewareExtensions));

            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = MediaTypeNames.Application.Json;
                    IExceptionHandlerFeature contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature != null)
                    {
                        if (contextFeature.Error is BelezanaWebApplicationException)
                        {
                            BelezanaWebApplicationException belezanaWebException = contextFeature.Error as BelezanaWebApplicationException;
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                            ErrorResponseViewModel errorModel = new ErrorResponseViewModel
                            {
                                ErrorCode = belezanaWebException.StatusCode.ToString(),
                                Message = contextFeature.Error.Message
                            };

                            await context.Response.WriteAsync(Newtonsoft.Json.JsonConvert.SerializeObject(errorModel));
                        }
                        else
                        {
                            logger.LogError($"Something went wrong: {contextFeature.Error}");
                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                            await context.Response.WriteAsync(new ErrorResponseViewModel()
                            {
                                Message = "Internal Server Error."
                            }.ToString());
                        }
                    }
                });
            });
        }
    }
}
