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

public class AddNoteCommand : IRequest<bool>
{
    public string Id { get; set; }
    public string Note { get; set; }

}

public class AddNoteCommandHandler : IRequestHandler<AddNoteCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public AddNoteCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(AddNoteCommand request, CancellationToken cancellationToken)
    {
        var basket = await _applicationDbContext.TransferBaskets.FirstOrDefaultAsync(x => x.Id == Guid.Parse(request.Id));
        if (basket == null)
        {
            throw new NotFoundException("Basket not found");
        }
        basket.Note = request.Note;
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
