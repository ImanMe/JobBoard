using FluentValidation;
using JobBoard.Core.DTOs;

namespace JobBoard.Core.Validations
{
    public class JobBoardUpdateDtoValidator : AbstractValidator<JobBoardUpdateDto>
    {
        public JobBoardUpdateDtoValidator()
        {
            RuleFor(reg => reg.Name).NotEmpty().MaximumLength(255);
            RuleFor(reg => reg.Id).NotEmpty();
        }
    }
}
