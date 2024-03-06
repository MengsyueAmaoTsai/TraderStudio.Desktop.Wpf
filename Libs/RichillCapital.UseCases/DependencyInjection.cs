using Microsoft.Extensions.DependencyInjection;

namespace RichillCapital.UseCases;

public static class DependencyInjection
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(assembly);

            // configuration.AddOpenBehavior(typeof(LoggingPipelineBehavior<,>));
            // configuration.AddOpenBehavior(typeof(QueryCachingPipelineBehavior<,>));
            // configuration.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
        });

        return services;
    }
}
