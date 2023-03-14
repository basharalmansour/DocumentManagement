using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Vehicles.Commands;
public class RemoveVehicleCommand : IRequest<bool>
{
    public int Id { get; set; }
}

public class RemoveVehicleCommandHandler : IRequestHandler<RemoveVehicleCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public RemoveVehicleCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper = null)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }

    public async Task<bool> Handle(RemoveVehicleCommand request, CancellationToken cancellationToken)
    {
        var deletedVehicle = _applicationDbContext.Vehicles.FirstOrDefault(x => x.Id == request.Id);
        deletedVehicle.IsDeleted = true;
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}