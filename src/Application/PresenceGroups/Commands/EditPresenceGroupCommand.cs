using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Enums;
using MediatR;

namespace CleanArchitecture.Application.PresenceGroups.Commands;
public class EditPresenceGroupCommand :CreatePresenceGroupCommand, IRequest<bool>
{
    public int Id { get; set; }
}
public class EditPresenceGroupCommandHandler : IRequestHandler<EditPresenceGroupCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public EditPresenceGroupCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper = null)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(EditPresenceGroupCommand request, CancellationToken cancellationToken)
    {
        var editedPrecenceGroup = _applicationDbContext.PresenceGroups.FirstOrDefault(x => x.Id == request.Id);
        _mapper.Map(request, editedPrecenceGroup);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
