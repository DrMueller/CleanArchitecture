using JetBrains.Annotations;
using Microsoft.AspNetCore.Builder;
using Mmu.CleanArchitecture.Common.Areas.Invariance;
using Mmu.CleanArchitecture.WebApi.Infrastructure.ExceptionHandling.Middlewares;

namespace Mmu.CleanArchitecture.WebApi.Infrastructure.ExceptionHandling.Initialization
{
    [PublicAPI]
    public static class ApplicationInitialization
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            Guard.ObjectNotNull(() => app);
            app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

            return app;
        }
    }
}