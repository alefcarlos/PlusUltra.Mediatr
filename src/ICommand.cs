using Flunt.Notifications;
using MediatR;

namespace PlusUltra.Mediatr
{
    public interface ICommand : IRequest<Notifiable>
    {
         
    }
}