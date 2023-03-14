using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities.Forms;
using MediatR;

namespace CleanArchitecture.Application.Forms.Commands;

public class EditFormCommand :CreateFormCommnad, IRequest<bool>
{
    public int Id { get; set; }
}
public class EditFormCommandHandler : IRequestHandler<EditFormCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public EditFormCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper = null)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(EditFormCommand request, CancellationToken cancellationToken)
    {
        var form = _applicationDbContext.Forms.FirstOrDefault(x => x.Id == request.Id);
        form.Questions.Clear();
        _mapper.Map(request, form);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
