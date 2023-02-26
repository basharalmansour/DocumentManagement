using CleanArchitecture.Application.Common.Interfaces;
using MassTransit;

namespace CleanArchitecture.Infrastructure.Services;

public class MessageBrokerService : IMessageBrokerService
{
    private readonly IPublishEndpoint _publish;

    public MessageBrokerService(IPublishEndpoint publish)
    {
        _publish = publish;
    }

    public async Task<bool> PublishMessage<T>(T msg)
    {
        try
        {
            await _publish.Publish(msg);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}