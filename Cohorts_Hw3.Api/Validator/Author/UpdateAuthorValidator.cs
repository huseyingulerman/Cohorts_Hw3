using Cohorts_Hw3.Api.Aplications.AuthorOperations.Commands;
using FluentValidation;

namespace Cohorts_Hw3.Api.Validator.Author
{
    public class UpdateAuthorValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Model.Name).MinimumLength(4).When(x => x.Model.Name.Trim() != string.Empty);
            RuleFor(x => x.Model.LastName).MinimumLength(4).When(x => x.Model.Name.Trim() != string.Empty);
            RuleFor(x => x.Model.BirthDate).NotEmpty().LessThan(DateTime.Now.Date);

        }
    }
}
