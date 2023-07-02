using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Entities.Forms;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Forms.Commands;

public class EditFormCommand : CreateFormCommand, IRequest<int>
{
    public int Id { get; set; }
}
public class EditFormCommandHandler : BaseCommandHandler, IRequestHandler<EditFormCommand, int>
{

    public EditFormCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {

    }
    public async Task<int> Handle(EditFormCommand request, CancellationToken cancellationToken)
    {
        var form = _applicationDbContext.Forms
            .Include(x=>x.Questions).ThenInclude(x=>x.DateQuestionOptions)
            .Include(x=>x.Questions).ThenInclude(x=>x.FileQuestionOptions)
            .Include(x=>x.Questions).ThenInclude(x=>x.MultiChoicesOptions)
            .FirstOrDefault(x => x.Id == request.Id);
        if (form == null)
            throw new Exception("Form was NOT found");

        form.DeleteByEdit();
        var newForm = _mapper.Map<Form>((CreateFormCommand)request);
        newForm.UniqueCode = form.UniqueCode;
        _applicationDbContext.Forms.Add(newForm);

        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return newForm.Id;
    }
}
