﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Serilog;
using System.Net;

namespace Hahn.Assesment.Presentation.Config.AppExtensions;

public static class ExceptionHandlerExtensions
{
    public static void UseGlobalExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(options =>
        {
            options.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = "application/json";
                var exception = context.Features.Get<IExceptionHandlerFeature>();
                if (exception != null)
                {
                    var message = $"An error occurred: {exception.Error.Message}";
                    var messageWithStackTrace = $"{message}\r\n{exception.Error.StackTrace}";
                    Log.Error(exception.Error, messageWithStackTrace);
                    await context.Response.WriteAsync(message).ConfigureAwait(false);
                }
            });
        });
    }
}