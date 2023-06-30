using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Application.Common;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.ServiceCategories.Commands;
using CleanArchitecture.Domain.Entities.Definitions;
using CleanArchitecture.Domain.Entities.SeviceCategories;
using CleanArchitecture.Domain.Entities.Vendors;
using CleanArchitecture.Domain.Enums;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Vendors.Commands;
public class EditVendorCommand : CreateVendorCommand, IRequest<int>
{
    public int VendorId { get; set; }
}
public class EditVendorCommandHandler : BaseCommandHandler, IRequestHandler<EditVendorCommand, int>
{

    public EditVendorCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }
    public async Task<int> Handle(EditVendorCommand request, CancellationToken cancellationToken)
    {
        var vendor = _applicationDbContext.Vendors
            .Include(x => x.Categories)
            .FirstOrDefault(x => x.Id == request.VendorId);
        if (vendor == null)
            throw new Exception("Vendor was NOT found");
        vendor.DeleteByEdit();

        //var newVendor = _mapper.Map<Vendor>((CreateVendorCommand)request);
        //newVendor.UniqueCode = vendor.UniqueCode;
        //_applicationDbContext.Vendors.Add(newVendor);
        //await _applicationDbContext.SaveChangesAsync(cancellationToken);
        //return newVendor.Id;
        ValidateVendorType(request);
        var newVendor = _mapper.Map<Vendor>(request);
        if (request.Logo != null)
           newVendor.Logo = FileManager.Create(request.Logo);
        var primaryUser = _mapper.Map<UserDetails>(request.Users);
        primaryUser.IsPrimary = true;
        newVendor.Users.Add(primaryUser);
        newVendor.UniqueCode = vendor.UniqueCode;
        _applicationDbContext.Vendors.Add(newVendor);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return newVendor.Id;
    }

    private void ValidateVendorType(EditVendorCommand request)
    {
        if (request.VendorOwnership == VendorOwnership.Private)
        {
            request.VendorType = null;
            if (request.OwnerName == null || request.OwnerSurname == null)
                throw new Exception("Owner Name & Surname are requested");
        }
        else if (request.VendorOwnership == VendorOwnership.Corporate)
        {
            request.OwnerName = null;
            request.OwnerSurname = null;
            if (request.VendorType == null)
                throw new Exception("Vendor Type must be selected");
        }
    }
}
