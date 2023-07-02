using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.Vendors;
using CleanArchitecture.Application.Common.Dtos;
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Enums;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Vendors.Commands;
public class RemoveVendorCommand : IRequest<bool>
{
    public int Id { get; set; }
}

public class DeleteVendorCommandHandler : BaseCommandHandler, IRequestHandler<RemoveVendorCommand, bool>
{
    public DeleteVendorCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }

    public async Task<bool> Handle(RemoveVendorCommand request, CancellationToken cancellationToken)
    {
        var deletedVendor =await _applicationDbContext.Vendors.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (deletedVendor == null)
            throw new Exception("Vendor was not found");
        deletedVendor.IsDeleted = true;
        deletedVendor.Status = RecordStatus.Deleted;
        _applicationDbContext.SaveChanges();
        return true;
    }
}