using CleanArchitecture.Application.Common.Dtos.Basket;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Basket.Commands;

public class RemoveBasketCommand : IRequest<RemoveTransferFromBasketResultDto>
{
    public string Id { get; set; }
}

public class RemoveBasketCommandHandler : IRequestHandler<RemoveBasketCommand, RemoveTransferFromBasketResultDto>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public RemoveBasketCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<RemoveTransferFromBasketResultDto> Handle(RemoveBasketCommand request, CancellationToken cancellationToken)
    {
        var basket = await _applicationDbContext.TransferBaskets
            .FirstOrDefaultAsync(x => x.Id == Guid.Parse(request.Id), cancellationToken);

        if (basket == null)
        {
            throw new NotFoundException("Basket Not Found!");
        }

        _applicationDbContext.TransferBaskets.Remove(basket);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return new RemoveTransferFromBasketResultDto {Result = true};
    }
}