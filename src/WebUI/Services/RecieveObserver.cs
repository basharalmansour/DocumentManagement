using MassTransit;

namespace CleanArchitecture.WebUI.Services;

public class RecieveObserver : IReceiveObserver
{
    public RecieveObserver()
    {
    }

    public Task ConsumeFault<T>(ConsumeContext<T> context, TimeSpan duration, string consumerType, Exception exception) where T : class
    {
        return Task.CompletedTask;
    }

    public Task PostConsume<T>(ConsumeContext<T> context, TimeSpan duration, string consumerType) where T : class
    {
        return Task.CompletedTask;
    }
    public Task PostReceive(ReceiveContext context)
    {
        return Task.CompletedTask;
    }

    public Task PreReceive(ReceiveContext context)
    {
        return Task.CompletedTask;
    }

    public Task ReceiveFault(ReceiveContext context, Exception exception)
    {
        return Task.CompletedTask;
    }
}