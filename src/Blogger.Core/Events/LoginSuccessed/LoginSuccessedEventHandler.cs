using MediatR;

namespace Blogger.Core.Events.LoginSuccessed
{
    public class LoginSuccessedEventHandler : INotificationHandler<LoginSuccessedEvent>
    {
        public Task Handle(LoginSuccessedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
