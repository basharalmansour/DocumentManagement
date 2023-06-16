using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.Vendors;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Entities.Definitions;
using MassTransit;
using MediatR;

namespace CleanArchitecture.Application.Vendors.Commands;
public class CreateUserCommand : CreateUserDetailsDto, IRequest<bool>
{

}

public class CreateUserCommandHandler : BaseCommandHandler, IRequestHandler<CreateUserCommand, bool>
{
    public CreateUserCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper, IPublishEndpoint publishEndpoint) : base(applicationDbContext, mapper, publishEndpoint)
    {
    }

    public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var vendor = _applicationDbContext.Vendors.FirstOrDefault(x => x.Id == request.VendorId);
        if (vendor == null)
            throw new Exception("Vendor was not found");
        var user = _mapper.Map<UserDetails>((CreateUserDetailsDto)request);
        vendor.UserDetails.Add(user);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}