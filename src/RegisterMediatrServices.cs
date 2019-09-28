using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PlusUltra.Mediatr.Pipelines;

namespace PlusUltra.Mediatr
{
    public static class RegisterMediatrServices
    {
        public static IServiceCollection AddMediatrServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FailFastRequestBehavior<,>));

            return services;
        }
    }
}