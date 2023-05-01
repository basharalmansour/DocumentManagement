using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using MassTransit;

namespace CleanArchitecture.Application.Common.Models;
public class BaseCommandQueryHandler
{
    internal readonly IApplicationDbContext _applicationDbContext;
    internal readonly IMapper _mapper;
    public BaseCommandQueryHandler(IApplicationDbContext applicationDbContext,IMapper mapper)
    {
        _mapper = mapper;
        _applicationDbContext = applicationDbContext;
    }
}

public class BaseCommandHandler : BaseCommandQueryHandler
{
    internal readonly IPublishEndpoint _publishEndpoint;
    public BaseCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper, IPublishEndpoint publishEndpoint):base(applicationDbContext, mapper)
    {
        _publishEndpoint = publishEndpoint;
    }
}

public class BaseQueryHandler : BaseCommandQueryHandler
{
    public BaseQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper):base(applicationDbContext,mapper)
    {
    }
}
