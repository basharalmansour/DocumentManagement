using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.Transfer;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities.Basket;
using MediatR;

namespace CleanArchitecture.Application.Basket.Commands;

public class AddInvoiceCommand : IRequest<AddInvoiceAddressResultDto>
{
    public string Id { get; set; } 
    public string TaxNo { get; set; }
    public string Title { get; set; }
    public string Taxoffice { get; set; }
    public string Province { get; set; }
    public string District { get; set; }
    public string InvoiceAddress { get; set; }
    public string AddressDetail { get; set; }
    public string Email { get; set; }
    public string Type { get; set; }
}

public class AddInvoiceCommandHandler : IRequestHandler<AddInvoiceCommand, AddInvoiceAddressResultDto>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public AddInvoiceCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }

    public async Task<AddInvoiceAddressResultDto> Handle(AddInvoiceCommand request, CancellationToken cancellationToken)
    {
         var baskets = _applicationDbContext.TransferBaskets.Where(x=>x.UniqueBasketId == request.Id && !x.IsClosed).ToList();
        if (!baskets.Any())
            throw new NotFoundException("Basket not found");
        foreach (var basket in baskets)
        {
              _mapper.Map<AddInvoiceCommand,TransferBasket>(request, basket);
        }
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return new AddInvoiceAddressResultDto()
        {
            Result = true
        };
    }
}
