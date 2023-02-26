using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Basket.Commands;

public class AddCouponCodeCommand : IRequest<bool>
{
    public string Id { get; set; }
    public string CouponCode { get; set; } 
}

public class AddCouponCodeCommandHandler : IRequestHandler<AddCouponCodeCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public AddCouponCodeCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(AddCouponCodeCommand request, CancellationToken cancellationToken)
    {
        var basket = await _applicationDbContext.TransferBaskets.FirstOrDefaultAsync(x=>x.Id == Guid.Parse(request.Id));
        if (basket == null)
        {
            throw new NotFoundException("Basket not found");
        }
        basket.Coupon = request.CouponCode;
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}

