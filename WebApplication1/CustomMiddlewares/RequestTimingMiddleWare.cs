using System.Diagnostics;
namespace WebApplication1.CustomMiddlewares
{
    public class RequestTimingMiddleWare
    {
        private readonly RequestDelegate _next;
        public RequestTimingMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            await _next(context);
            watch.Stop();
            
            Console.WriteLine($"{context.Request.Path}: {watch.ElapsedMilliseconds} ms");
        }
    }
}
