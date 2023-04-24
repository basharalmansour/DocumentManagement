using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;

namespace CleanArchitecture.Application.Common.Models;
public class BaseCommandQueryHandler
{
    internal readonly IApplicationDbContext _applicationDbContext;
    internal readonly IMapper _mapper;
    public BaseCommandQueryHandler(IMapper mapper, IApplicationDbContext applicationDbContext = null)
    {
        _mapper = mapper;
        _applicationDbContext = applicationDbContext;
    }
}
