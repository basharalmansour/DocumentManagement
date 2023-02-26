using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.CondoLife;
using CleanArchitecture.Application.Common.Dtos.Customer;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Enums;
using CleanArchitecture.Domain.Enums.CondoLifeEnums;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Customer.Commands;

public class CreateCustomerCommand : IRequest<CreateIntegrationUserResulDto>
{
    public CreateIntegrationCustomerDto Customer { get; set; }
    public RequestIntegrationType Integration { get; set; }
}

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateIntegrationUserResulDto>
{
    private readonly IMapper _mapper;
    private readonly ICondolifeHttpClient _condoLifeHttpClient;
    private readonly IVeriSoftHttpClient _veriSoftHttpClient;
    private readonly ILogger<CreateCustomerCommandHandler> _logger;
    private readonly ICurrentUserService _currentUserService;
    public CreateCustomerCommandHandler(IMapper mapper, ICondolifeHttpClient condoLifeHttpClient, IVeriSoftHttpClient veriSoftHttpClient, ILogger<CreateCustomerCommandHandler> logger, ICurrentUserService currentUserService)
    {

        _mapper = mapper;
        _condoLifeHttpClient = condoLifeHttpClient;
        _veriSoftHttpClient = veriSoftHttpClient;
        _logger = logger;
        _currentUserService = currentUserService;
    }

    public async Task<CreateIntegrationUserResulDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customerInfoFromIntegration = await _veriSoftHttpClient.GetCustomerInfoAsync(request.Customer.IntegrationUserId, cancellationToken);
        var newCondoUser = _mapper.Map<CreateCondoUserDto>(request.Customer);
        List<Task> asyncProcesses = new List<Task>();
        CreateCondoUserResultDto condoLifeCreateUserResponse = default;
        newCondoUser.DataSource = (int)CondoRecordDataSource.Verisoft;
        CondoUserInfoDto existsCondoUser = default;
        try
        {
            existsCondoUser = await _condoLifeHttpClient.GetUserInfoByPhoneNumberAndEmail(request.Customer.PhoneNumber, request.Customer.Email, cancellationToken);
            if (existsCondoUser.integrationUserId == customerInfoFromIntegration.Customer_ID.ToString())
                throw new ConflictException("Kullanıcı Mevcut!");
            condoLifeCreateUserResponse = new CreateCondoUserResultDto();

        }
        catch (BadRequestException)
        {

            
        }
        if (existsCondoUser == null)
        {
            condoLifeCreateUserResponse = await _condoLifeHttpClient.CreateCustomerAsync(newCondoUser, cancellationToken);
        }
        else
        {
            var updateResult = await _condoLifeHttpClient.UpdateUserInfo(newCondoUser, Guid.Parse(existsCondoUser.userId), cancellationToken);
            if (!updateResult)
                throw new Exception("User update process failed!");
            condoLifeCreateUserResponse.id = existsCondoUser.userId;
        }


        if (String.IsNullOrEmpty(condoLifeCreateUserResponse.id))
            throw new Exception("Condolife api, user creating process failed");
        _logger.LogInformation("Condolife user created!");
        var getVeriSoftCardPropGroupTask = await _veriSoftHttpClient.GetCardPropertyGroupsAsync(cancellationToken);
        var condoMemberships = await _condoLifeHttpClient.GetMembershipsAsync(cancellationToken);
        List<CreateCondoUserMembershipDto> membershipUsers = new List<CreateCondoUserMembershipDto>();
        var membership = condoMemberships.FirstOrDefault(x => x.integrationMembershipId == customerInfoFromIntegration.CardPropertyGroup_ID.ToString());
        membershipUsers.Add(new CreateCondoUserMembershipDto()
        {
            MemberShipId = membership.id.Value,
            UserId = Guid.Parse(condoLifeCreateUserResponse.id),
            StartDate = DateTime.Now,
            EndDate = customerInfoFromIntegration.Card.ExpireDate,
            SiteId =Guid.Parse(_currentUserService.SiteId)
        });
        await _condoLifeHttpClient.UpsertCustomerMembershipAsync(membershipUsers, cancellationToken);
        _logger.LogInformation("User Membership created!");
        MembershipType membershipType = getVeriSoftCardPropGroupTask
                        .FirstOrDefault(x => x.CardPropertyGroup_ID == customerInfoFromIntegration.CardPropertyGroup_ID)?.Name.ToLower() == "edition" ? MembershipType.EDITION : MembershipType.CLASSIC;
        return new CreateIntegrationUserResulDto()
        {
            Id = condoLifeCreateUserResponse.id.ToString(),
            MembershipType = membershipType
        };
    }
}