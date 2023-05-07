﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Entities.Forms;
using MassTransit;
using MediatR;

namespace CleanArchitecture.Application.Forms.Commands;

public class EditFormCommand :CreateFormCommand, IRequest<int>
{
    public int Id { get; set; }
}
public class EditFormCommandHandler : BaseCommandHandler, IRequestHandler<EditFormCommand, int>
{

    public EditFormCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper, IPublishEndpoint publishEndpoint) : base(applicationDbContext, mapper, publishEndpoint)
    {

    }
    public async Task<int> Handle(EditFormCommand request, CancellationToken cancellationToken)
    {
        var form = _applicationDbContext.Forms.FirstOrDefault(x => x.Id == request.Id);
        if (form == null)
            throw new Exception("Form was NOT found");
        form.Questions.Clear();
        _mapper.Map(request, form);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return request.Id;
    }
}
