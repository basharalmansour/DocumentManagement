using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using MediatR;

namespace CleanArchitecture.Application.Vehicles.Commands;
public class EditVehicleCommand :CreateVehicleCommand , IRequest<bool>
{
    public int Id { get; set; }
}

public class EditVehicleCommandHandler : BaseCommandQueryHandler, IRequestHandler<EditVehicleCommand, bool>
{

    public EditVehicleCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper = null) : base(mapper, applicationDbContext)
    {
    }

    public async Task<bool> Handle(EditVehicleCommand request, CancellationToken cancellationToken)
    {
        var editedVehicle = _applicationDbContext.Vehicles.FirstOrDefault(x => x.Id == request.Id);
        _mapper.Map(request, editedVehicle);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true; 
    }
}
