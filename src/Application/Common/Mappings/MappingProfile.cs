using System.Reflection;
using AutoMapper;
using CleanArchitecture.Application.Basket.Commands;
using CleanArchitecture.Application.Common.Dtos.Category;
using CleanArchitecture.Application.Common.Dtos.Common;
using CleanArchitecture.Application.Common.Dtos.CondoLife;
using CleanArchitecture.Application.Common.Dtos.Customer;
using CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
using CleanArchitecture.Application.Common.Dtos.Hotel.Arrival.RequestDtos;
using CleanArchitecture.Application.Common.Dtos.Hotel.Offer.RequestDtos;
using CleanArchitecture.Application.Common.Dtos.Hotel.OfferDetail.RequestDtos;
using CleanArchitecture.Application.Common.Dtos.Hotel.Price.RequestDtos;
using CleanArchitecture.Application.Common.Dtos.Hotel.Product.RequestDtos;
using CleanArchitecture.Application.Common.Dtos.Memberships;
using CleanArchitecture.Application.Common.Dtos.Orders;
using CleanArchitecture.Application.Common.Dtos.POI;
using CleanArchitecture.Application.Common.Dtos.POI.Cart.RequestDtos;
using CleanArchitecture.Application.Common.Dtos.POI.Transfer.ResponseDtos;
using CleanArchitecture.Application.Common.Dtos.Products;
using CleanArchitecture.Application.Common.Dtos.Transactions;
using CleanArchitecture.Application.Common.Dtos.Transfer;
using CleanArchitecture.Application.Common.Dtos.VeriSoft.Customer.RequestDtos;
using CleanArchitecture.Application.Common.Dtos.VeriSoft.Customer.ResponseDtos;
using CleanArchitecture.Application.Common.Dtos.VeriSoft.Parameter.ResponseDtos;
using CleanArchitecture.Application.Common.Dtos.VeriSoft.Transaction.ResponseDtos;
using CleanArchitecture.Application.CondoLife.Commands;
using CleanArchitecture.Application.DocumentsTemplate.Commands;
using CleanArchitecture.Application.Hotel.Queries;
using CleanArchitecture.Application.IntegrationServices.Commands;
using CleanArchitecture.Application.Verisoft.Commands;
using CleanArchitecture.Domain.Entities.Basket;
using CleanArchitecture.Domain.Entities.Documents;
using CleanArchitecture.Domain.Entities.Integrations;
using CleanArchitecture.Domain.Entities.Orders;
using CleanArchitecture.Domain.Entities.Products;
using CleanArchitecture.Domain.Enums.VeriSoftEnums;

namespace CleanArchitecture.Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<GetCustomerInfoResultDto, UpdateCustomerInfoRequestDto>();
        CreateMap<UpdateCondolifeUserCommand, UpdateCustomerInfoRequestDto>()
        .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
        .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Surname))
        .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Name))
        .ForMember(dest => dest.MaritialDate, opt => opt.MapFrom(src => src.MaritialDate))
        .ForMember(dest => dest.MaritialStatus, opt => opt.MapFrom(src => src.MaritialStatus ? "1": "0"))
        .ForMember(dest => dest.IdentityNumber, opt => opt.MapFrom(src => src.CitizenNumber))
        .AfterMap((src, dest) =>
        {
            if(dest.ContactInfo != null && dest.BusinessInfo.IsContactAddress == 1)
                dest.ContactInfo.Email1 = src.Email;
            else
            {
                dest.BusinessInfo.Email = src.Email;
            }
        });
        CreateMap<Integration, GetCategoryDto>()
            .ForMember(x => x.HasProcuct, opt => opt.MapFrom(dest => dest.IsCanHasProduct));
        CreateMap<CondoUserInfoDto, GetPOIAuthKeyRequestDto>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.userId))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.email))
            .ForMember(dest => dest.TavPassportNo, opt => opt.MapFrom(src => src.tavPassportNo))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.phoneNumber));
        CreateMap<GetTransactionsResultDto, GetPassedTransactionDto>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.TransactionDate))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => 0))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.PropertyGroup));
        CreateMap<GetCountriesResultDto, GetCountryDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.NameEn, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Country_ID));
        CreateMap<GetCitiesResultDto, GetCityDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.NameEn, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.City_ID));
        CreateMap<GetCountiesResultDto, GetDistrictDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.NameEn, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.County_ID));

        CreateMap<TransferListDto, GetPassedTransactionDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => "Transfer Hizmeti"))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => (decimal)src.ttlPC_.prc))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.date));
        CreateMap<VerisoftCreateCustomerRequestDto, CreateCondoUserDto>()
            .ForMember(dest => dest.AgreementTextAccept, opt => opt.MapFrom(src => true))
            .ForMember(dest => dest.GenderId, opt => opt.MapFrom(src => src.Sex == "0" ? 1 : 2))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.ContactInfo.Mobile))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.ContactInfo.Email1))
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
            .ForMember(dest => dest.CitizenNumber, opt => opt.MapFrom(src => src.IdentityNumber))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.WorkAddress, opt => opt.MapFrom(src => src.BusinessInfo.Address));

        CreateMap<GetCustomerInfoResultDto, GetIntegrationCustomerRegisterInfoDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FirstName +" "+ src.MiddleName))
            .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.ContactInfo.Email1))
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.ContactInfo.Mobile))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Sex == "0" ? VerisoftGender.Male : VerisoftGender.Female));

        CreateMap<CreateIntegrationCustomerDto, CreateCondoUserDto>()
           .ForMember(dest => dest.GenderId, opt => opt.MapFrom(src => src.GenderId == 0 ? 1 : 2))
           .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
           .ForMember(dest => dest.TavPassportNo, opt => opt.MapFrom(src => src.TavPassportNo))
           .ForMember(dest => dest.IntegrationUserId, opt => opt.MapFrom(src => src.IntegrationUserId))
           .ForMember(dest => dest.KvkkPermissionAccept, opt => opt.MapFrom(src => src.KvkkPermissionAccept))
           .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
           .ForMember(dest => dest.CitizenNumber, opt => opt.MapFrom(src => src.IdentityNumber))
           .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
           .ForMember(dest => dest.DataSource, opt => opt.Ignore())
           .ForMember(dest => dest.WorkAddress, opt => opt.Ignore());
        CreateMap<UpdateVerisoftCustomerCommand, CreateCondoUserDto>()
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false))
            .ForMember(dest => dest.TavPassportNo, opt => opt.MapFrom(src => src.Card.CardNo))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.ContactInfo.Mobile))
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
            .ForMember(dest => dest.MaritialDate, opt => opt.MapFrom(src => src.MaritialDate))
            .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.ContactInfo.Email1))
            .ForMember(dest => dest.CitizenNumber, opt => opt.MapFrom(src => src.IdentityNumber))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName +" "+ src.MiddleName))
            .ForMember(dest => dest.WorkAddress, opt => opt.MapFrom(src => src.BusinessInfo.Address));


        CreateMap<CartTransferRequestDtoUi, CartTransferRequestDto>()
            .ForMember(dest => dest.extser_id_, opt => opt.MapFrom(src => src.extsers.ToDictionary(x => x.Id, x => x.Name)));

        CreateMap<CartTransferRequestDto, CartTransfer>()
            .ForMember(dest => dest.Coupon, opt => opt.MapFrom(src => src.coupon))
            .ForMember(dest => dest.Suid, opt => opt.MapFrom(src => src.suid))
            .ForMember(dest => dest.Lvtd_Id, opt => opt.MapFrom(src => src.lvtd_id));
        CreateMap<TransferListDto, GetTransactionsDto>()
            .ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => src.date))
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.pax_phone))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.cart_code))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.statusR))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => "Transfer"))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.pay_info_a =="EDITION_FREE" ? 0.00 : src.ttlPC_.prc))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.vehicle_photo))
            .AfterMap((src, dest) =>
            {
                dest.UserName = src.pax_name.Split(' ')[0];
                if (src.pax_name.Split(' ').Length > 1)
                    dest.UserSurname = src.pax_name.Split(' ')[1];
            });
        CreateMap<GetProductPriceResultDto, GetMembershipPriceDto>()
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Amount))
            .ForMember(dest => dest.DiscountedPrice, opt => opt.MapFrom(src => src.DiscountedAmount));
        CreateMap<Product, GetProductsDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        CreateMap<CondoUserInfoDto, VerisoftCreateCustomerRequestDto>()
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.birthDate))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.surname))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.name))
            .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => ""))
            .ForMember(dest => dest.Sex, opt => opt.MapFrom(src => src.genderId == 1 ? 0 : 1))
            .ForMember(dest => dest.NameOnCard, opt => opt.MapFrom(src => src.name + " " + src.surname))
            .ForMember(dest => dest.IdentityNumber, opt => opt.MapFrom(src => src.citizenNumber))
            .ForMember(dest => dest.CustomerStatus_ID, opt => opt.Ignore());
        CreateMap<TransferListPaxDto, PassengerDto>()
             .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.adult))
             .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.adult));
        CreateMap<TransferListExtraServiceDto, ExtraDto>()
              .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.title))
              .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.pc_.cid))
              .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.info_b))
              .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.info_a))
             .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.pc_.prc));
        CreateMap<PaxDto, PassengerDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => ""))
            .ForMember(dest => dest.IdentityNumber, opt => opt.MapFrom(src => src.idno))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.nationality));
        CreateMap<TransferListDto, GetTransactionDetailDto>()
            .ForMember(dest => dest.BookingNumber, opt => opt.MapFrom(src => src.code))
            .ForMember(dest => dest.VehicleTitle, opt => opt.MapFrom(src => src.vehicle_title))
            .ForMember(dest => dest.CarImage, opt => opt.MapFrom(src => src.vehicle_photo))
            .ForMember(dest => dest.UserNote, opt => opt.MapFrom(src => src.note_ur))
            .ForMember(dest => dest.CarTypeR, opt => opt.MapFrom(src => src.vehicle_typeR))
            .ForMember(dest => dest.CarPlateNumber, opt => opt.MapFrom(src => src.driver_.plate))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.date))
            .ForMember(dest => dest.DateR, opt => opt.MapFrom(src => src.dateR))
            .ForMember(dest => dest.DriverName, opt => opt.MapFrom(src => src.driver_.name))
            .ForMember(dest => dest.DriverPhoneNumber, opt => opt.MapFrom(src => src.driver_.phone))
            .ForMember(dest => dest.EndPoint, opt => opt.MapFrom(src => src.to))
            .ForMember(dest => dest.EpDescription, opt => opt.MapFrom(src => src.to_b))
            .ForMember(dest => dest.EpDetail, opt => opt.MapFrom(src => src.to_a))
            .ForMember(dest => dest.UserPhoneNumber, opt => opt.MapFrom(src => src.pax_phone))
            .ForMember(dest => dest.UserIdentityNo, opt => opt.MapFrom(src => src.pax_idno))
            .ForMember(dest => dest.Passengers, opt => opt.MapFrom(src => src.pax_info_))
            .ForMember(dest => dest.Extras, opt => opt.MapFrom(src => src.extser_))
            .ForMember(dest => dest.SiteName, opt => opt.MapFrom(src => "TAV"))
            .ForMember(dest => dest.StartPoint, opt => opt.MapFrom(src => src.fr))
            .ForMember(dest => dest.SpDetail, opt => opt.MapFrom(src => src.fr_a))
            .ForMember(dest => dest.SpDescription, opt => opt.MapFrom(src => src.fr_b))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.statusR))
            .ForMember(dest => dest.TransactionDetailNo, opt => opt.MapFrom(src => src.cart_code))
            .ForMember(dest => dest.IsCanCancel, opt => opt.MapFrom(src => true))
            .ForMember(dest => dest.IsCanChange, opt => opt.MapFrom(src => true))
            .ForMember(dest => dest.TransactionName, opt => opt.MapFrom(src => "Transfer Hizmet"))
            .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.pax_email)) 
            .AfterMap((src, dest) =>
            {
                dest.PaymentDetail.TotalPrice = src.pay_info_a == "EDITION_FREE" ? 0.00 : src.ttlPC_.prc;
                dest.PaymentDetail.Price = src.pay_info_a == "EDITION_FREE" ? 0.00 : src.pc_.prc;
                dest.PaymentDetail.Date = src.date;
                dest.PaymentDetail.RevervationTime = src.date;
                if(src.pax_name.Split(" ").Length>1)
                    dest.UserSurname = src.pax_name.Split(" ")[1];
                dest.UserName = src.pax_name.Split(" ")[0];
                
                
            });

        CreateMap<GetCustomerCreditsResultDto, GetCustomerAdvantagesDto>()
            .ForMember(dest => dest.AdvantageName, opt => opt.MapFrom(src => src.PropertyGroupName))
            .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.CreditCount));

        ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());

        CreateMap<CreateTransferOrderDto, CartCheckOutTransferRequestDto>()
            .ForMember(dest => dest.extser_id_, opt => opt.MapFrom(src => src.extsers.ToDictionary(x => x.Id, x => x.Name)));
        CreateMap<PreCheckoutTransferCommand, CartCheckOutTransferRequestDto>()
            .ForMember(dest => dest.extser_id_, opt => opt.MapFrom(src => src.PreCheckoutInfo.extsers.ToDictionary(x => x.Id, x => x.Name)))
            .ForMember(dest => dest.lvtd_id, opt => opt.MapFrom(src => src.PreCheckoutInfo.lvtd_id))
            .AfterMap((src, dest) =>
            {
                if (src.pax_ != null)
                {
                    dest.pax_adult = src.pax_.Count(x => x.type.ToLower().Contains("adult")) + 1;
                    dest.pax_baby = src.pax_.Count(x => x.type.ToLower().Contains("baby"));
                    dest.pax_child = src.pax_.Count(x => x.type.ToLower().Contains("child"));
                }
                else
                {
                    dest.pax_adult = 1;
                    dest.pax_baby = 0;
                    dest.pax_child = 0;
                }


            });

        CreateMap<OrderPropertyDetails, OrderPropertyDetailsDto>()
            .ForMember(x => x.Detail, y => y.MapFrom(z => (OrderPropertyDetailsDto)z.Detail));
        CreateMap<AddInvoiceCommand, TransferBasket>()
            .ForMember(dest => dest.InvoiceEmail, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.InvoiceAddressDetail, opt => opt.MapFrom(src => src.AddressDetail))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.InvoiceType, opt => opt.MapFrom(src => src.Type));
        #region Hotel

        CreateMap<GetArrivalAutoCompleteQuery, GetArrivalAutoCompleteRequestDto>();
        CreateMap<GetProductInfoQuery, GetProductInfoRequestDto>();
        CreateMap<GetOffersQuery, GetOffersRequestDto>();
        CreateMap<GetOfferDetailsQuery, GetOfferDetailsRequestDto>();
        CreateMap<PriceSearchHotelQuery, PriceSearchHotelRequestDto>();
        CreateMap<PriceSearchLocationQuery, PriceSearchLocationRequestDto>();

        #endregion






        CreateMap<DocumentTemplate, GetDocumentTemplateDto>();
        CreateMap<AddDocumentTemplateRequest, DocumentTemplate>();
        CreateMap<AddDocumentTemplateType, DocumentTemplateType>();
        CreateMap<EditDocumentTemplate, DocumentTemplate>();

    }




    private void ApplyMappingsFromAssembly(Assembly assembly)
    {
        var types = assembly.GetExportedTypes()
            .Where(t => t.GetInterfaces().Any(i =>
                i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
            .ToList();

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);

            var methodInfo = type.GetMethod("Mapping")
                ?? type.GetInterface("IMapFrom`1")!.GetMethod("Mapping");

            methodInfo?.Invoke(instance, new object[] { this });

        }
    }
}
