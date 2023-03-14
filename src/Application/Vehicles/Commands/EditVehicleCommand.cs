using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Vehicles.Commands;
public class EditVehicleCommand :CreateVehicleCommand , IRequest<bool>
{
    public int Id { get; set; }
}

public class EditVehicleCommandHandler : IRequestHandler<EditVehicleCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public EditVehicleCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper = null)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }

    public async Task<bool> Handle(EditVehicleCommand request, CancellationToken cancellationToken)
    {
        var editedVehicle = _applicationDbContext.Vehicles.FirstOrDefault(x => x.Id == request.Id);
        _mapper.Map(request, editedVehicle);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true; 
    }
}
