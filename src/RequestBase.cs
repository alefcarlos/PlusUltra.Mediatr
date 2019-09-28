using Flunt.Notifications;
using MediatR;

namespace PlusUltra.Mediatr
{
    public class RequestBase<T> : Notifiable, IRequest<T>
        where T : class
    {

    }
}