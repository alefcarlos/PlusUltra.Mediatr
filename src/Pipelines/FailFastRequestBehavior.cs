using System.Threading;
using System.Threading.Tasks;
using Flunt.Notifications;
using MediatR;
using Microsoft.Extensions.Logging;

namespace PlusUltra.Mediatr.Pipelines
{
    public class FailFastRequestBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
            where TRequest : Notifiable, IRequest<TResponse>
            where TResponse : Notifiable, new()
    {
        public FailFastRequestBehavior(ILogger<FailFastRequestBehavior<TRequest, TResponse>> logger)
        {
            this.logger = logger;
        }

        private readonly ILogger logger;

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            logger.LogInformation($"Validating {typeof(TRequest).Name}");

            if (request.Invalid)
            {
                var response = new TResponse();
                response.AddNotifications(request.Notifications);
                return Task.FromResult(response);
            }

            return next();
        }
    }
}