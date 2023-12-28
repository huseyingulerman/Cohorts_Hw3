using Cohorts_Hw3.Api.Aplications.AuthorOperations.Commands;
using FluentValidation;

namespace Cohorts_Hw3.Api.Validator.Author
{
    public class DeleteAuthorValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);

        }
    }
}
