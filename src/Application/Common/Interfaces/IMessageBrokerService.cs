namespace CleanArchitecture.Application.Common.Interfaces;

public interface IMessageBrokerService
{ 
    Task<bool> PublishMessage<T>(T msg);
}