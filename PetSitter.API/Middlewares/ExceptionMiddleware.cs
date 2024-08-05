using System.Net;
using PetSitter.API.Validation;
using PetSitter.Domain.Common;

namespace PetSitter.API.Middlewares;

public class ExceptionMiddleware
{
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        
            var errorInfo = new ErrorInfo(Errors.General.Internal(ex.Message));
        
            var envelope = Envelope.Error([errorInfo]);
        
            var error = new Error("server.internal", ex.Message);
        
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        
            await context.Response.WriteAsJsonAsync(envelope);
        }
    }
}