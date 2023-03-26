using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.Customer;
using CleanArchitecture.Application.Common.Dtos.Forms;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Customer.Commands;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.Forms;
using MediatR;
using Microsoft.Extensions.Options;

namespace CleanArchitecture.Application.Forms.Commands;
public class CreateFormCommand : IRequest<int>
{
    public string Name { get; set; }
    public List<AddQuestionRequest> Questions { get; set; }
}
public class CreateFormCommnadHandler : IRequestHandler<CreateFormCommand, int>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public CreateFormCommnadHandler(IApplicationDbContext applicationDbContext, IMapper mapper = null)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<int> Handle(CreateFormCommand request, CancellationToken cancellationToken)
    {
        var form = _mapper.Map<Form>(request);
        _applicationDbContext.Forms.Add(form);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return form.Id;
    }
}
