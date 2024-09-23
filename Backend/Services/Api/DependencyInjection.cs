using BuildingBlocks.Exceptions.Handler;

namespace API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCarter();

        services.AddExceptionHandler<CustomExceptionHandler>();

        // services.AddCors(
        //     o => o.AddPolicy("MyPolicy", configurePolicy =>
        // {
        //      configurePolicy
        //         .AllowAnyOrigin()
        //         .AllowAnyMethod()
        //         .AllowAnyHeader();
        // }));
        services.AddCors(o => o.AddPolicy("MyPolicy", configurePolicy =>
        {
            configurePolicy
              // .AllowAnyOrigin()
              .WithOrigins("http://192.168.255.38:4200")
               .AllowAnyMethod()
               .AllowAnyHeader()
                .AllowCredentials(); 
        }));
        return services;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {
        app.UseForwardedHeaders(new ForwardedHeadersOptions()
    {
        ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedFor |
                           Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedProto
    });
        app.UseCors("MyPolicy");
        app.MapCarter();

        app.UseExceptionHandler(options => { });

        return app;
    }
}
