using FluentValidation;
using JobBoard.Core.DTOs;

namespace JobBoard.Core.Validations
{
    public class JobBoardCreateDtoValidator : AbstractValidator<JobBoardCreateDto>
    {
        public JobBoardCreateDtoValidator()
        {
            RuleFor(reg => reg.Name).NotEmpty().MaximumLength(255);
        }
    }
}
