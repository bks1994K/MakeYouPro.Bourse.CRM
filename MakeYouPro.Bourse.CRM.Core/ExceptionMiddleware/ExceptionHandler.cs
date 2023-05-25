﻿using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace MakeYouPro.Bourse.CRM.Core.ExceptionMiddleware
{
    public class ExceptionHandler
    {
        private RequestDelegate _next;
        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (AlreadyExistException ex)
            {
                var result = JsonSerializer.Serialize(new { Error = "AlreadyExistException Error:" + ex.Message });
                context.Response.StatusCode = 409;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(result);
            }
            catch (NotFoundException ex)
            {
                var result = JsonSerializer.Serialize(new { Error = "NotFoundException Error:" + ex.Message });
                context.Response.StatusCode = 404;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(result);
            }
            catch (ArgumentNullException ex)
            {
                var result = JsonSerializer.Serialize(new { Error = "ArgumentNullException Error:" + ex.Message });
                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(result);
            }
        }
    }
}
