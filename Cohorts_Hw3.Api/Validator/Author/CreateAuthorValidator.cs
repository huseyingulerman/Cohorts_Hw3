using Cohorts_Hw3.Api.Aplications.AuthorOperations.Commands;
using FluentValidation;

namespace Cohorts_Hw3.Api.Validator.Author
{
    public class CreateAuthorValidator : AbstractValidator<AddAuthorCommand>
    {
        public CreateAuthorValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Model.LastName).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Model.BirthDate).NotEmpty().LessThan(DateTime.Now.Date);
        }
    }
}
