using MassTransit;
using MessageBroker.Events.DocumentTemplates;
using System.Diagnostics;

namespace CleanArchitecture.WebUI.Consumers;

public class DocumentTemplateRemovedConsumer : IConsumer<DocumentTemplateRemoved>
{
    public async Task Consume(ConsumeContext<DocumentTemplateRemoved> context)
    {
        Debug.WriteLine($"DocumentTemplateRemovedConsumer 1");
    }
}
