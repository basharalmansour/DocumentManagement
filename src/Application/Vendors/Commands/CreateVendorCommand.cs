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

namespace CleanArchitecture.Application.Vendors.Commands;
public class CreateVendorCommand : IRequest<int>
{
    public LanguageString Name { get; set; }
    public RecordStatus Status { get; set; }
    public IFormFile Logo { get; set; }
    public LanguageString Description { get; set; }
    public VendorOwnership VendorOwnership { get; set; }
    public VendorType? VendorType { get; set; }
    public LanguageString OwnerName { get; set; }
    public LanguageString OwnerSurname { get; set; }
    public string Title { get; set; }
    public LanguageString CompanyName { get; set; }
    public string BrandName { get; set; }
    public string MersisNo { get; set; }
    public int ChamberOfCommerceId { get; set; }
    public string TradeRegistrationNo { get; set; }
    public int TaxCountyId { get; set; }
    public int TaxRoomId { get; set; }
    public int TaxIdentityNumberId { get; set; }
    public List<CreateUserDetailsDto> UserDetails { get; set; }
    public CreateAddressInfoDto AddressInfoId { get; set; }
    public List<CreateVendorPersonnelDto> VendorPersonnels { get; set; }
    public List<int> Vehicles { get; set; }
    public List<int> VendorsCategories { get; set; }
}

public class CreateVendorCommandHandler : BaseCommandHandler, IRequestHandler<CreateVendorCommand, int>
{
    public CreateVendorCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper, IPublishEndpoint publishEndpoint) : base(applicationDbContext, mapper, publishEndpoint)
    {
    }

    public async Task<int> Handle(CreateVendorCommand request, CancellationToken cancellationToken)
    {
        if (request.Logo != null)
            FileManager.Create(request.Logo);
        if (request.VendorOwnership == VendorOwnership.Private)
        {
            request.VendorType = null;
            if (request.OwnerName == null || request.OwnerSurname == null)
                throw new Exception("Owner Name & SurName are requested");
        }
        else if (request.VendorOwnership == VendorOwnership.Corporate)
        {
            request.OwnerName = null;
            request.OwnerSurname = null;
            if (request.VendorType == null)
                throw new Exception("Vendor Type must be selected");
        }
        request.UserDetails[0].IsPrimary = true;
        var vendor = _mapper.Map<Vendor>(request);
        vendor.UniqueCode = UniqueCode.CreateUniqueCode(8, false, "V");
        _applicationDbContext.Vendors.Add(vendor);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return vendor.Id;
    }
}