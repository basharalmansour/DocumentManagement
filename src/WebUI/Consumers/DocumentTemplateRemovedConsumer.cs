using MassTransit;
using System.Diagnostics;

namespace CleanArchitecture.WebUI.Consumers;

public class DocumentTemplateRemovedConsumer : IConsumer<DocumentTemplateRemoved>
{
    public async Task Consume(ConsumeContext<DocumentTemplateRemoved> context)
    {
        Debug.WriteLine($"DocumentTemplateRemovedConsumer 1");
    }
}
public class DocumentTemplateRemoved
{
    public int DocumentTemplateId { get; set; }
}
