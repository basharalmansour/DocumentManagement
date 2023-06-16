using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.ServiceCategories.Commands;
using CleanArchitecture.Domain.Entities.SeviceCategories;
using CleanArchitecture.Domain.Entities.Vendors;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Vendors.Commands;
public class EditVendorCommand : CreateVendorCommand, IRequest<int>
{
    public int Id { get; set; }
}
public class EditVendorCommandHandler : BaseCommandHandler, IRequestHandler<EditVendorCommand, int>
{

    public EditVendorCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper, IPublishEndpoint publishEndpoint) : base(applicationDbContext, mapper, publishEndpoint)
    {
    }
    public async Task<int> Handle(EditVendorCommand request, CancellationToken cancellationToken)
    {
        var vendor = _applicationDbContext.Vendors
            .Include(x => x.Categories)
            .FirstOrDefault(x => x.Id == request.Id);
        if (vendor == null)
            throw new Exception("Vendor was NOT found");
        vendor.DeleteByEdit();

        var newVendor = _mapper.Map<Vendor>((CreateVendorCommand)request);
        newVendor.UniqueCode = newVendor.UniqueCode;
        _applicationDbContext.Vendors.Add(newVendor);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return newVendor.Id;
    }
}