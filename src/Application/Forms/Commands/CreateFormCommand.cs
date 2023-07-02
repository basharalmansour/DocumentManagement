using AutoMapper;
using CleanArchitecture.Application.Common;
using CleanArchitecture.Application.Common.Dtos.Customer;
using CleanArchitecture.Application.Common.Dtos.Forms;
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Entities.Forms;
using CleanArchitecture.Domain.Entities.Presences.PresenceGroups;
using CleanArchitecture.Domain.Enums;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Options;

namespace CleanArchitecture.Application.Forms.Commands;
public class CreateFormCommand : IRequest<int>
{
    public LanguageString Name { get; set; }
    public List<CreateQuestionRequest> Questions { get; set; }
}
public class CreateFormCommandHandler : BaseCommandHandler, IRequestHandler<CreateFormCommand, int>
{
    public CreateFormCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }
    public async Task<int> Handle(CreateFormCommand request, CancellationToken cancellationToken)
    {
        ValidateForm(request);
        var form = _mapper.Map<Form>(request);
        form.UniqueCode = UniqueCode.CreateUniqueCode(8, false, "F");
        _applicationDbContext.Forms.Add(form);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return form.Id;
    }

    private void ValidateForm(CreateFormCommand request)
    {
        foreach (var question in request.Questions)
        {
            if (question.QuestionType == QuestionType.MultiAnswers || question.QuestionType == QuestionType.OneOfMany)
            {
                question.DateQuestionOptions = null;
                question.FileQuestionOptions = null;
            }
            else if (question.QuestionType == QuestionType.FileAnswer)
            {
                question.DateQuestionOptions = null;
                question.MultiChoicesQuestions = null;
            }
            else if (question.QuestionType == QuestionType.DateAnswer)
            {
                question.FileQuestionOptions = null;
                question.MultiChoicesQuestions = null;
            }
            else if(question.QuestionType == QuestionType.TextAnswer)
            {
                question.DateQuestionOptions = null;
                question.MultiChoicesQuestions = null;
                question.FileQuestionOptions = null;
            }
        }
    }
}
