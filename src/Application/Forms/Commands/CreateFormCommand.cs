using AutoMapper;
using CleanArchitecture.Application.Common;
using CleanArchitecture.Application.Common.Dtos.Customer;
using CleanArchitecture.Application.Common.Dtos.Forms;
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Entities.Forms;
using CleanArchitecture.Domain.Entities.Presences.PresenceGroups;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Options;

namespace CleanArchitecture.Application.Forms.Commands;
public class CreateFormCommand : IRequest<int>
{
    public LanguageString Name { get; set; }
    public List<CreateQuestionRequest> Questions { get; set; }
}
public class CreateFormCommandHandler : BaseCommandHandler, IRequestHandler<CreateFormCommand, int>
{
    public CreateFormCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper, IPublishEndpoint publishEndpoint) : base(applicationDbContext, mapper, publishEndpoint)
    {
    }
    public async Task<int> Handle(CreateFormCommand request, CancellationToken cancellationToken)
    {
        var form = _mapper.Map<Form>(request);
        form.UniqueCode = UniqueCode.CreateUniqueCode(8, false, "F");
        _applicationDbContext.Forms.Add(form);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return form.Id;
    }
}
