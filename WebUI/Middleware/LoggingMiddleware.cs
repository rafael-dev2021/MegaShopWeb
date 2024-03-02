using System.Diagnostics;
using System.Text;

namespace WebUI.Middleware;
public class LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<LoggingMiddleware> _logger = logger;
    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        try
        {
            await LogAuditEvent(context.Request, context.Response, _logger);
            await _next(context);
        }
        finally
        {
            stopwatch.Stop();
            _logger.LogInformation($"Request Duration: {stopwatch.ElapsedMilliseconds}ms");
        }
    }

    private static async Task LogAuditEvent(HttpRequest request, HttpResponse response, ILogger logger)
    {
        var requestBody = await GetRequestBodyAsync(request);

        var requestInfo = new
        {
            Timestamp = DateTime.UtcNow,
            RequestMethod = request.Method,
            RequestPath = request.Path,
            QueryString = request.QueryString.ToString(),
            request.Headers.UserAgent,
            RequestBody = requestBody,
        };

        var responseInfo = new
        {
            response.StatusCode,
        };

        logger.LogInformation($"Audit Event: {requestInfo.RequestMethod} {requestInfo.RequestPath}{requestInfo.QueryString} - UserAgent: {requestInfo.UserAgent}");
        logger.LogInformation($"Request Body: {requestInfo.RequestBody}");
        logger.LogInformation($"Response: Status {responseInfo.StatusCode}");
    }

    private static async Task<string> GetRequestBodyAsync(HttpRequest request)
    {
        request.EnableBuffering();
        var buffer = new byte[Convert.ToInt32(request.ContentLength)];
        await request.Body.ReadAsync(buffer);
        var requestBody = Encoding.UTF8.GetString(buffer);
        request.Body.Seek(0, SeekOrigin.Begin);
        return requestBody;
    }
}