namespace Exab.Test.Application;
public static  class StartupExtension
{
    public static void ConfigureApplicationService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddFluentValidationAutoValidation();
        services.AddAuthenticationConfiguration(configuration);

    }

    private static IServiceCollection AddAuthenticationConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
         services.Configure<JwtSettings>( configuration.GetSection("jwtSettings"));

         services.AddSingleton(sp =>

         sp.GetRequiredService<IOptions<JwtSettings>>().Value);

         services.AddSingleton<IJwtProvider, JwtProvider>();

        return services;
    }
}
