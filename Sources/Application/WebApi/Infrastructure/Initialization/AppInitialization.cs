using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Mmu.CleanArchitecture.WebApi.Infrastructure.ExceptionHandling.Initialization;

namespace Mmu.CleanArchitecture.WebApi.Infrastructure.Initialization
{
    internal static class AppInitialization
    {
        internal static void InitializeApplication(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseGlobalExceptionHandler();
             app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(
                config =>
                {
                    config.SwaggerEndpoint("/swagger/v1/swagger.json", "CleanArchitecture API");
                });

            app.UseCors("All");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}