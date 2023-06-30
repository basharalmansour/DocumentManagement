using AutoMapper;
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Entities.Vendors;
using CleanArchitecture.Domain.Enums;
using MassTransit;
using MediatR;
using CleanArchitecture.Application.Common.Dtos.Vendors;
using CleanArchitecture.Application.Common.Dtos;
using CleanArchitecture.Application.Common;
using Microsoft.AspNetCore.Http;
using CleanArchitecture.Domain.Entities.Definitions;

namespace CleanArchitecture.Application.Vendors.Commands;
public class CreateVendorCommand : IRequest<int>
{
    public string Name { get; set; }
    public RecordStatus Status { get; set; }
    public IFormFile Logo { get; set; }
    public LanguageString Description { get; set; }
    public VendorOwnership VendorOwnership { get; set; }
    public VendorType? VendorType { get; set; }
    public string OwnerName { get; set; }
    public string OwnerSurname { get; set; }
    public string Title { get; set; }
    public string CompanyName { get; set; }
    public string BrandName { get; set; }
    public string MersisNo { get; set; }
    public int ChamberOfCommerceId { get; set; }
    public string TradeRegistrationNo { get; set; }
    public int TaxCountyId { get; set; }
    public int TaxRoomId { get; set; }
    public string TaxIdentityNumberId { get; set; }
    public CreateUserDetailsDto Users { get; set; }
    public CreateAddressInfoDto AddressInfo { get; set; }
    public List<int> Categories { get; set; }
}

public class CreateVendorCommandHandler : BaseCommandHandler, IRequestHandler<CreateVendorCommand, int>
{
    public CreateVendorCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }

    public async Task<int> Handle(CreateVendorCommand request, CancellationToken cancellationToken)
    {
        ValidateVendorType(request);
        var vendor = _mapper.Map<Vendor>(request);
        if (request.Logo != null)
            vendor.Logo= FileManager.Create(request.Logo);
        var primaryUser= _mapper.Map<UserDetails>(request.Users);
        primaryUser.IsPrimary = true;
        vendor.Users.Add(primaryUser);
        vendor.UniqueCode = UniqueCode.CreateUniqueCode(8, false, "V");
        _applicationDbContext.Vendors.Add(vendor);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return vendor.Id;
    }

    private void ValidateVendorType(CreateVendorCommand request)
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